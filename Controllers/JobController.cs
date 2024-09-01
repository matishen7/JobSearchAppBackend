using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSearchAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Job>>> GetJobs()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJob(int id)
        {
            var job = await _jobService.GetJobByIdAsync(id);
            if (job == null)
                return NotFound();

            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] Job job)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _jobService.AddJobAsync(job);
            return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] Job job)
        {
            if (id != job.Id)
                return BadRequest("Job ID mismatch.");

            var existingJob = await _jobService.GetJobByIdAsync(id);
            if (existingJob == null)
                return NotFound();

            await _jobService.UpdateJobAsync(job);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var existingJob = await _jobService.GetJobByIdAsync(id);
            if (existingJob == null)
                return NotFound();

            await _jobService.DeleteJobAsync(id);
            return NoContent();
        }
    }
}
