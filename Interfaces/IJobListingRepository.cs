using JobSearchAppBackend.Models;

namespace JobSearchAppBackend.Interfaces
{
    public interface IJobListingRepository
    {
        Task<List<JobListing>> GetAllJobsAsync();
        Task<JobListing> GetJobByIdAsync(int jobId);
        Task<int> AddJobAsync(JobListing job);
        Task UpdateJobAsync(JobListing job);
        Task DeleteJobAsync(int jobId);
    }
}
