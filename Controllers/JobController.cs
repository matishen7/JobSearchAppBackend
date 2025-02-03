using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using JobSearchAppBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        [Authorize(Roles = "Employer,Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateJobListing([FromBody] JobListingCreateDTO createJobDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var company = await _companyService.GetCompanyByIdAsync(createJobDto.CompanyId);
            if (company == null)
                return NotFound();

            var jobListingId = await _jobListingService.AddJobListingAsync(createJobDto);
            return CreatedAtAction(nameof(CreateJobListing), new { id = jobListingId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobListing([FromBody] JobListingCreateDTO job)
        {
            var existingCompany = await _companyService.GetCompanyByIdAsync(job.CompanyId);
            if (existingCompany == null)
                return NotFound();

            var existingJob = await _jobListingService.GetJobListingByIdAsync(job.JobId);
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
