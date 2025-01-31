using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Models;

namespace JobSearchAppBackend.Interfaces
{
    public interface IJobApplicationService
    {
        Task<List<JobApplicationDTO>> GetAllJobApplicationsAsync();
        Task<JobApplicationDTO> GetJobApplicationByIdAsync(int jobApplicationId);
        Task<int> AddJobApplicationAsync(JobApplicationCreateDTO jobApplication);
        Task UpdateJobApplicationAsync(JobApplicationCreateDTO jobApplication);
        Task DeleteJobApplicationAsync(int jobApplicationId);
    }
}
