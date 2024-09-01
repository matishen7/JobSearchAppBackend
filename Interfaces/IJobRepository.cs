using JobSearchAppBackend.Models;

namespace JobSearchAppBackend.Interfaces
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllJobsAsync();
        Task<Job> GetJobByIdAsync(int jobId);
        Task AddJobAsync(Job job);
        Task UpdateJobAsync(Job job);
        Task DeleteJobAsync(int jobId);
    }
}
