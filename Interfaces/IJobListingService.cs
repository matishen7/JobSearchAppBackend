using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Models;

namespace JobSearchAppBackend.Interfaces
{
    public interface IJobListingService
    {
        Task<List<JobListingDTO>> GetAllJobsAsync();
        Task<JobListingDTO> GetJobListingByIdAsync(int jobId);
        Task<int> AddJobListingAsync(JobListingCreateDTO job);
        Task UpdateJobAsync(JobListingCreateDTO job);
        Task DeleteJobAsync(int jobId);
    }
}
