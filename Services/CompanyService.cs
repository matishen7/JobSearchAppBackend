using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSearchAppBackend.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await _companyRepository.GetAllCompaniesAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int CompanyId)
        {
            return await _companyRepository.GetCompanyByIdAsync(CompanyId);
        }

        public async Task AddCompanyAsync(Company Company)
        {
            await _companyRepository.AddCompanyAsync(Company);
        }

        public async Task UpdateCompanyAsync(Company Company)
        {
            await _companyRepository.UpdateCompanyAsync(Company);
        }

        public async Task DeleteCompanyAsync(int CompanyId)
        {
            await _companyRepository.DeleteCompanyAsync(CompanyId);
        }
    }
}
