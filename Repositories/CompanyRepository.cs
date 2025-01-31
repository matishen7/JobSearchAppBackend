using JobSearchAppBackend.Data;
using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSearchAppBackend.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await _context.Companies.Include(j => j.JobListings).AsNoTracking().ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int companyId)
        {
            return await _context.Companies.Include(j => j.JobListings).AsNoTracking().FirstOrDefaultAsync(j => j.Id == companyId);
        }

        public async Task<int> AddCompanyAsync(Company Company)
        {
            await _context.Companies.AddAsync(Company);
            await _context.SaveChangesAsync();
            return Company.Id;
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            try
            {
                var existingCompany = await _context.Companies.FindAsync(company.Id);
                if (existingCompany != null)
                {
                    existingCompany.Name = company.Name;
                    existingCompany.Description = company.Description;
                    existingCompany.Location = company.Location;
                    existingCompany.Website = company.Website;
                    existingCompany.Industry = company.Industry;

                    _context.Companies.Update(existingCompany);
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving companies.", ex);
            }
        }

        public async Task DeleteCompanyAsync(int companyId)
        {
            var company = await _context.Companies.FindAsync(companyId);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }
    }
}
