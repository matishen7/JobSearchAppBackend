using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly IJobListingService _jobListingService;

        public JobApplicationController(
            IJobApplicationService jobApplicationService,
            IJobListingService jobListingService)
        {
            _jobApplicationService = jobApplicationService;
            _jobListingService = jobListingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JobApplicationDTO>>> GetJobApplications()
        {
            var jobApplications = await _jobApplicationService.GetAllJobApplicationsAsync();
            return Ok(jobApplications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplicationDTO>> GetJobApplication(int id)
        {
            var jobApplication = await _jobApplicationService.GetJobApplicationByIdAsync(id);
            if (jobApplication == null)
                return NotFound();

            return Ok(jobApplication);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobApplication([FromBody] JobApplicationCreateDTO JobApplicationCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate that the JobListing exists
            var jobListing = await _jobListingService.GetJobListingByIdAsync(JobApplicationCreateDTO.JobListingId);
            if (jobListing == null)
                return NotFound("Job Listing not found.");

            var jobApplicationId = await _jobApplicationService.AddJobApplicationAsync(JobApplicationCreateDTO);
            return CreatedAtAction(nameof(GetJobApplication), new { id = jobApplicationId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobApplication([FromBody] JobApplicationCreateDTO JobApplicationCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var jobListing = await _jobListingService.GetJobListingByIdAsync(JobApplicationCreateDTO.JobListingId);
            if (jobListing == null)
                return NotFound("Job Listing not found.");

            var existingJobApplication = await _jobApplicationService.GetJobApplicationByIdAsync(JobApplicationCreateDTO.JobApplicationId);
            if (existingJobApplication == null)
                return NotFound();

            await _jobApplicationService.UpdateJobApplicationAsync(JobApplicationCreateDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobApplication(int id)
        {
            var existingJobApplication = await _jobApplicationService.GetJobApplicationByIdAsync(id);
            if (existingJobApplication == null)
                return NotFound();

            await _jobApplicationService.DeleteJobApplicationAsync(id);
            return NoContent();
        }
    }
}
