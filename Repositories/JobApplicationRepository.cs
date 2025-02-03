using JobSearchAppBackend.Data;
using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobSearchAppBackend.Repositories
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly AppDbContext _context;

        public JobApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobApplication>> GetAllJobApplicationsAsync()
        {
            return await _context.Applications.Where(c => !c.Removed).Include(j => j.JobListing).AsNoTracking().ToListAsync();
        }

        public async Task<JobApplication> GetJobApplicationByIdAsync(int jobApplicationId)
        {
            return await _context.Applications.Where(c => !c.Removed).Include(j => j.JobListing).AsNoTracking().FirstOrDefaultAsync(j => j.JobApplicationId == jobApplicationId);
        }

        public async Task<int> AddJobApplicationAsync(JobApplication jobApplication)
        {
            await _context.Applications.AddAsync(jobApplication);
            await _context.SaveChangesAsync();
            return jobApplication.JobApplicationId;
        }

        public async Task UpdateJobApplicationAsync(JobApplication jobApplication)
        {
            _context.ChangeTracker.Clear();
            var existingJobApplication = await _context.Applications.FindAsync(jobApplication.JobApplicationId);
            if (existingJobApplication != null)
            {
                existingJobApplication.ApplicantEmail = jobApplication.ApplicantEmail;
                existingJobApplication.ApplicantPhone = jobApplication.ApplicantPhone;
                existingJobApplication.ApplicantName = jobApplication.ApplicantName;
                existingJobApplication.CoverLetter = jobApplication.CoverLetter;
                existingJobApplication.JobListingId = jobApplication.JobListingId;
                existingJobApplication.ResumeUrl = jobApplication.ResumeUrl;

                _context.Applications.Attach(existingJobApplication);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteJobApplicationAsync(int jobApplicationId)
        {
            var jobApplication = await _context.Applications.FindAsync(jobApplicationId);
            if (jobApplication != null)
            {
                jobApplication.Removed = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
