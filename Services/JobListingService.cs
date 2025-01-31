using AutoMapper;
using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSearchAppBackend.Services
{
    public class JobListingService : IJobListingService
    {
        private readonly IJobListingRepository _jobListingRepository;
        private readonly IMapper _mapper;
        public JobListingService(IJobListingRepository jobListingRepository, IMapper mapper)
        {
            _jobListingRepository = jobListingRepository;
            _mapper = mapper;
        }

        public async Task<List<JobListing>> GetAllJobsAsync()
        {
            return await _jobListingRepository.GetAllJobsAsync();
        }

        public async Task<JobListing> GetJobByIdAsync(int jobId)
        {
            return await _jobListingRepository.GetJobByIdAsync(jobId);
        }

        public async Task AddJobAsync(JobListingDTO createJobDto)
        {
            var job = _mapper.Map<JobListing>(createJobDto);
            await _jobListingRepository.AddJobAsync(job);
        }

        public async Task UpdateJobAsync(JobListingDTO createJobDto)
        {
            var job = _mapper.Map<JobListing>(createJobDto);
            await _jobListingRepository.UpdateJobAsync(job);
        }

        public async Task DeleteJobAsync(int jobId)
        {
            await _jobListingRepository.DeleteJobAsync(jobId);
        }
    }
}
