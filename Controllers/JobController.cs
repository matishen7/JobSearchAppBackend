using JobSearchAppBackend.DTOs;
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
        private readonly IJobListingService _jobService;

        public JobsController(IJobListingService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JobListing>>> GetJobs()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobListing>> GetJob(int id)
        {
            var job = await _jobService.GetJobByIdAsync(id);
            if (job == null)
                return NotFound();

            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] JobListingDTO createJobDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _jobService.AddJobAsync(createJobDto);
            return CreatedAtAction(nameof(CreateJob), new { id = createJobDto.Id }, createJobDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] JobListingDTO job)
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
