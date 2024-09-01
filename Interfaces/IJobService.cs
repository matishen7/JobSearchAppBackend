using JobSearchAppBackend.Models;

namespace JobSearchAppBackend.Interfaces
{
    public interface IJobService
    {
        Task<List<Job>> GetAllJobsAsync();
        Task<Job> GetJobByIdAsync(int jobId);
        Task AddJobAsync(Job job);
        Task UpdateJobAsync(Job job);
        Task DeleteJobAsync(int jobId);
    }
}
