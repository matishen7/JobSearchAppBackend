using AutoMapper;
using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;

namespace JobSearchAppBackend.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobListingRepository _jobListingRepository;
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IMapper _mapper;
        public JobApplicationService(IJobListingRepository jobListingRepository, IMapper mapper, IJobApplicationRepository jobApplicationRepository)
        {
            _jobListingRepository = jobListingRepository;
            _mapper = mapper;
            _jobApplicationRepository = jobApplicationRepository;
        }

        public async Task<List<JobApplicationDTO>> GetAllJobApplicationsAsync()
        {
            var jobApplications = await _jobApplicationRepository.GetAllJobApplicationsAsync(); ;
            var jobApplicationsDto = _mapper.Map<List<JobApplicationDTO>>(jobApplications);
            return jobApplicationsDto;
        }

        public async Task<JobApplicationDTO> GetJobApplicationByIdAsync(int jobId)
        {
            var jobApplication = await _jobApplicationRepository.GetJobApplicationByIdAsync(jobId);
            var jobApplicationDto = _mapper.Map<JobApplicationDTO>(jobApplication);
            return jobApplicationDto;
        }

        public async Task<int> AddJobApplicationAsync(JobApplicationCreateDTO createJobApplicationDto)
        {
            var job = _mapper.Map<JobApplication>(createJobApplicationDto);
            return await _jobApplicationRepository.AddJobApplicationAsync(job);
        }

        public async Task UpdateJobApplicationAsync(JobApplicationCreateDTO createJobDto)
        {
            var job = _mapper.Map<JobApplication>(createJobDto);
            await _jobApplicationRepository.UpdateJobApplicationAsync(job);
        }

        public async Task DeleteJobApplicationAsync(int jobId)
        {
            await _jobApplicationRepository.DeleteJobApplicationAsync(jobId);
        }
    }
}
