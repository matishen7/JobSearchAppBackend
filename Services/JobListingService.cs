using AutoMapper;
using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using JobSearchAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        public async Task<List<JobListingDTO>> GetAllJobsAsync()
        {
            var jobListings = await _jobListingRepository.GetAllJobsAsync(); ;
            var jobListingsDto = _mapper.Map<List<JobListingDTO>>(jobListings);
            return jobListingsDto;
        }

        public async Task<JobListingDTO> GetJobListingByIdAsync(int jobId)
        {
            var jobListing = await _jobListingRepository.GetJobByIdAsync(jobId);
            var jobListingDto = _mapper.Map<JobListingDTO>(jobListing);
            return jobListingDto;
        }

        public async Task AddJobListingAsync(JobListingDTO createJobDto)
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
