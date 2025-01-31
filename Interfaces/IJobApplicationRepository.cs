using JobSearchAppBackend.Models;

namespace JobSearchAppBackend.Interfaces
{
    public interface IJobApplicationRepository
    {
        Task<List<JobApplication>> GetAllJobApplicationsAsync();
        Task<JobApplication> GetJobApplicationByIdAsync(int jobApplicationId);
        Task<int> AddJobApplicationAsync(JobApplication jobApplication);
        Task UpdateJobApplicationAsync(JobApplication jobApplication);
        Task DeleteJobApplicationAsync(int jobApplicationId);
    }
}
