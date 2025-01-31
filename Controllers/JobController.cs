using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using JobSearchAppBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSearchAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobListingController : ControllerBase
    {
        private readonly IJobListingService _jobListingService;
        private readonly ICompanyService _companyService;

        public JobListingController(IJobListingService jobListingService, ICompanyService companyService)
        {
            _jobListingService = jobListingService;
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JobListing>>> GetJobListings()
        {
            var jobs = await _jobListingService.GetAllJobsAsync();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobListing>> GetJobListing(int id)
        {
            var job = await _jobListingService.GetJobListingByIdAsync(id);
            if (job == null)
                return NotFound();

            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobListing([FromBody] JobListingDTO createJobDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Company = await _companyService.GetCompanyByIdAsync(createJobDto.CompanyId);
            if (Company == null)
                return NotFound();

            await _jobListingService.AddJobListingAsync(createJobDto);
            return CreatedAtAction(nameof(CreateJobListing), new { id = createJobDto.Id }, createJobDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJobListing(int id, [FromBody] JobListingDTO job)
        {
            if (id != job.Id)
                return BadRequest("Job ID mismatch.");

            var existingJob = await _jobListingService.GetJobListingByIdAsync(id);
            if (existingJob == null)
                return NotFound();

            await _jobListingService.UpdateJobAsync(job);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobListing(int id)
        {
            var existingJob = await _jobListingService.GetJobListingByIdAsync(id);
            if (existingJob == null)
                return NotFound();

            await _jobListingService.DeleteJobAsync(id);
            return NoContent();
        }
    }
}
