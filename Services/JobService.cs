using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSearchAppBackend.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<List<Job>> GetAllJobsAsync()
        {
            return await _jobRepository.GetAllJobsAsync();
        }

        public async Task<Job> GetJobByIdAsync(int jobId)
        {
            return await _jobRepository.GetJobByIdAsync(jobId);
        }

        public async Task AddJobAsync(Job job)
        {
            await _jobRepository.AddJobAsync(job);
        }

        public async Task UpdateJobAsync(Job job)
        {
            await _jobRepository.UpdateJobAsync(job);
        }

        public async Task DeleteJobAsync(int jobId)
        {
            await _jobRepository.DeleteJobAsync(jobId);
        }
    }
}
