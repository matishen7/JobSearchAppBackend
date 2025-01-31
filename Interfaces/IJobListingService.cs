using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Models;

namespace JobSearchAppBackend.Interfaces
{
    public interface IJobListingService
    {
        Task<List<JobListing>> GetAllJobsAsync();
        Task<JobListing> GetJobByIdAsync(int jobId);
        Task AddJobAsync(JobListingDTO job);
        Task UpdateJobAsync(JobListingDTO job);
        Task DeleteJobAsync(int jobId);
    }
}
