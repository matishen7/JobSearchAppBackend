using JobSearchAppBackend.Data;
using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobSearchAppBackend.Repositories
{
    public class JobRepository : IJobListingRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobListing>> GetAllJobsAsync()
        {
            return await _context.Jobs.Include(j => j.Company).AsNoTracking().ToListAsync();
        }

        public async Task<JobListing> GetJobByIdAsync(int jobId)
        {
            return await _context.Jobs.Include(j => j.Company).AsNoTracking().FirstOrDefaultAsync(j => j.JobId == jobId);
        }

        public async Task AddJobAsync(JobListing job)
        {
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJobAsync(JobListing job)
        {
            _context.ChangeTracker.Clear();
            var existingJobListing = await _context.Jobs.FindAsync(job.JobId);
            if (existingJobListing != null)
            {
                existingJobListing.Title = job.Title;
                existingJobListing.Location = job.Location;
                existingJobListing.Description = job.Description;
                existingJobListing.CompanyId = job.CompanyId;

                _context.Jobs.Attach(existingJobListing);
                await _context.SaveChangesAsync();
            }

        }

        public async Task DeleteJobAsync(int jobId)
        {
            var job = await _context.Jobs.FindAsync(jobId);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }
        }
    }
}
