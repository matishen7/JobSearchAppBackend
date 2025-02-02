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
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobListingRepository _jobListingRepository;
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<JobApplicationService> _logger;

        public JobApplicationService(
            IJobListingRepository jobListingRepository,
            IJobApplicationRepository jobApplicationRepository,
            IMapper mapper,
            ILogger<JobApplicationService> logger)
        {
            _jobListingRepository = jobListingRepository ?? throw new ArgumentNullException(nameof(jobListingRepository));
            _jobApplicationRepository = jobApplicationRepository ?? throw new ArgumentNullException(nameof(jobApplicationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<JobApplicationDTO>> GetAllJobApplicationsAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all job applications.");
                var jobApplications = await _jobApplicationRepository.GetAllJobApplicationsAsync();
                var jobApplicationsDto = _mapper.Map<List<JobApplicationDTO>>(jobApplications);
                _logger.LogInformation("Retrieved {Count} job applications.", jobApplicationsDto?.Count ?? 0);
                return jobApplicationsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving job applications.");
                throw new ApplicationException("An error occurred while retrieving job applications.", ex);
            }
        }

        public async Task<JobApplicationDTO> GetJobApplicationByIdAsync(int jobApplicationId)
        {
            try
            {
                _logger.LogInformation("Retrieving job application with ID {JobApplicationId}.", jobApplicationId);
                var jobApplication = await _jobApplicationRepository.GetJobApplicationByIdAsync(jobApplicationId);
                if (jobApplication is null)
                {
                    _logger.LogWarning("Job application with ID {JobApplicationId} not found.", jobApplicationId);
                    throw new KeyNotFoundException($"Job application with ID {jobApplicationId} was not found.");
                }
                var jobApplicationDto = _mapper.Map<JobApplicationDTO>(jobApplication);
                _logger.LogInformation("Retrieved job application with ID {JobApplicationId}.", jobApplicationId);
                return jobApplicationDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving job application with ID {JobApplicationId}.", jobApplicationId);
                throw new ApplicationException("An error occurred while retrieving job application.", ex);
            }
        }

        public async Task<int> AddJobApplicationAsync(JobApplicationCreateDTO createJobApplicationDto)
        {
            try
            {
                if (createJobApplicationDto is null)
                {
                    _logger.LogError("JobApplicationCreateDTO is null. Cannot add job application.");
                    throw new ArgumentNullException(nameof(createJobApplicationDto));
                }

                _logger.LogInformation("Adding a new job application.");
                var jobApplication = _mapper.Map<JobApplication>(createJobApplicationDto);
                int newJobApplicationId = await _jobApplicationRepository.AddJobApplicationAsync(jobApplication);
                _logger.LogInformation("Job application added with ID {JobApplicationId}.", newJobApplicationId);
                return newJobApplicationId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding job application.");
                throw new ApplicationException("An error occurred while adding job application.", ex);
            }
        }

        public async Task UpdateJobApplicationAsync(JobApplicationCreateDTO createJobApplicationDto)
        {
            try
            {
                if (createJobApplicationDto is null)
                {
                    _logger.LogError("JobApplicationCreateDTO is null. Cannot update job application.");
                    throw new ArgumentNullException(nameof(createJobApplicationDto));
                }

                _logger.LogInformation("Updating job application.");
                var jobApplication = _mapper.Map<JobApplication>(createJobApplicationDto);
                await _jobApplicationRepository.UpdateJobApplicationAsync(jobApplication);
                _logger.LogInformation("Job application updated.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating job application.");
                throw new ApplicationException("An error occurred while updating job application.", ex);
            }
        }

        public async Task DeleteJobApplicationAsync(int jobApplicationId)
        {
            try
            {
                _logger.LogInformation("Deleting job application with ID {JobApplicationId}.", jobApplicationId);
                var jobApplication = await _jobApplicationRepository.GetJobApplicationByIdAsync(jobApplicationId);
                if (jobApplication is null)
                {
                    _logger.LogWarning("Job application with ID {JobApplicationId} not found.", jobApplicationId);
                    throw new KeyNotFoundException($"Job application with ID {jobApplicationId} was not found.");
                }
                await _jobApplicationRepository.DeleteJobApplicationAsync(jobApplicationId);
                _logger.LogInformation("Job application with ID {JobApplicationId} deleted.", jobApplicationId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting job application with ID {JobApplicationId}.", jobApplicationId);
                throw new ApplicationException("An error occurred while deleting job application.", ex);
            }
        }
    }
}
