using JobSearchAppBackend.Models;
using JobSearchAppBackend.ViewModels;

namespace JobSearchAppBackend.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int companyId);
        Task AddCompanyAsync(CompanyDTO company);
        Task UpdateCompanyAsync(CompanyDTO company);
        Task DeleteCompanyAsync(int companyId);
    }
}
