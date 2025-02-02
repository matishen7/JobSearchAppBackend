using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using Microsoft.Extensions.Logging;

namespace JobSearchAppBackend.Services
{
    public class JobListingService : IJobListingService
    {
        private readonly IJobListingRepository _jobListingRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<JobListingService> _logger;

        public JobListingService(IJobListingRepository jobListingRepository, IMapper mapper, ILogger<JobListingService> logger)
        {
            _jobListingRepository = jobListingRepository ?? throw new ArgumentNullException(nameof(jobListingRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<JobListingDTO>> GetAllJobsAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all job listings.");
                var jobListings = await _jobListingRepository.GetAllJobsAsync();
                var jobListingsDto = _mapper.Map<List<JobListingDTO>>(jobListings);
                _logger.LogInformation("Retrieved {Count} job listings.", jobListingsDto?.Count ?? 0);
                return jobListingsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving job listings.");
                throw new ApplicationException("An error occurred while retrieving job listings.", ex);
            }
        }

        public async Task<JobListingDTO> GetJobListingByIdAsync(int jobId)
        {
            try
            {
                _logger.LogInformation("Retrieving job listing with ID {JobId}.", jobId);
                var jobListing = await _jobListingRepository.GetJobByIdAsync(jobId);
                if (jobListing is null)
                {
                    _logger.LogWarning("Job listing with ID {JobId} not found.", jobId);
                    throw new KeyNotFoundException($"Job listing with ID {jobId} was not found.");
                }
                var jobListingDto = _mapper.Map<JobListingDTO>(jobListing);
                _logger.LogInformation("Retrieved job listing with ID {JobId}.", jobId);
                return jobListingDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving job listing with ID {JobId}.", jobId);
                throw new ApplicationException("An error occurred while retrieving job listing.", ex);
            }
        }

        public async Task<int> AddJobListingAsync(JobListingCreateDTO createJobDto)
        {
            try
            {
                if (createJobDto is null)
                {
                    _logger.LogError("JobListingCreateDTO is null. Cannot add job listing.");
                    throw new ArgumentNullException(nameof(createJobDto));
                }

                _logger.LogInformation("Adding a new job listing.");
                var job = _mapper.Map<JobListing>(createJobDto);
                int newJobId = await _jobListingRepository.AddJobAsync(job);
                _logger.LogInformation("Job listing added with ID {JobId}.", newJobId);
                return newJobId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a job listing.");
                throw new ApplicationException("An error occurred while adding a job listing.", ex);
            }
        }

        public async Task UpdateJobAsync(JobListingCreateDTO createJobDto)
        {
            try
            {
                if (createJobDto is null)
                {
                    _logger.LogError("JobListingCreateDTO is null. Cannot update job listing.");
                    throw new ArgumentNullException(nameof(createJobDto));
                }

                _logger.LogInformation("Updating job listing.");
                var job = _mapper.Map<JobListing>(createJobDto);
                await _jobListingRepository.UpdateJobAsync(job);
                _logger.LogInformation("Job listing updated.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the job listing.");
                throw new ApplicationException("An error occurred while updating the job listing.", ex);
            }
        }

        public async Task DeleteJobAsync(int jobId)
        {
            try
            {
                _logger.LogInformation("Deleting job listing with ID {JobId}.", jobId);
                var jobListing = await _jobListingRepository.GetJobByIdAsync(jobId);
                if (jobListing is null)
                {
                    _logger.LogWarning("Job listing with ID {JobId} not found for deletion.", jobId);
                    throw new KeyNotFoundException($"Job listing with ID {jobId} was not found.");
                }

                await _jobListingRepository.DeleteJobAsync(jobId);
                _logger.LogInformation("Job listing with ID {JobId} deleted.", jobId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the job listing with ID {JobId}.", jobId);
                throw new ApplicationException("An error occurred while deleting the job listing.", ex);
            }
        }
    }
}
