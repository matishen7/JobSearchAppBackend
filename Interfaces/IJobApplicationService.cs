using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Models;

namespace JobSearchAppBackend.Interfaces
{
    public interface IJobApplicationService
    {
        Task<List<JobApplicationDto>> GetAllJobApplicationsAsync();
        Task<JobApplicationDto> GetJobApplicationByIdAsync(int jobApplicationId);
        Task<int> AddJobApplicationAsync(JobApplicationCreateDto jobApplication);
        Task UpdateJobApplicationAsync(JobApplicationCreateDto jobApplication);
        Task DeleteJobApplicationAsync(int jobApplicationId);
    }
}
