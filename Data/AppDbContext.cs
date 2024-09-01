using JobSearchAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSearchAppBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> Applications { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
