using JobSearchAppBackend.Data;
using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            return await _context.Jobs.Include(j => j.Company).ToListAsync();
        }

        public async Task<JobListing> GetJobByIdAsync(int jobId)
        {
            return await _context.Jobs.Include(j => j.Company).FirstOrDefaultAsync(j => j.Id == jobId);
        }

        public async Task AddJobAsync(JobListing job)
        {
            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJobAsync(JobListing job)
        {
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();
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
