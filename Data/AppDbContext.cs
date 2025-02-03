using JobSearchAppBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobSearchAppBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<JobListing> Jobs { get; set; }
        public DbSet<JobApplication> Applications { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "b3f43b8e-9e40-4142-bf98-b3d8c8238f1e",
                    Name = "JobSeeker",
                    NormalizedName = "JOBSEEKER"
                },
                new IdentityRole
                {
                    Id = "7e8f56f6-b3bb-4b78-bd92-b39eb4b2e8f1",
                    Name = "Employer",
                    NormalizedName = "EMPLOYER"
                },
                new IdentityRole
                {
                    Id = "29d892c8-2f43-4e55-bd91-3c4e5d8e7d19",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );
        }

    }
}
