using JobSearchAppBackend.Models;

namespace JobSearchAppBackend.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(int companyId);
        Task AddCompanyAsync(Company company);
        Task UpdateCompanyAsync(Company job);
        Task DeleteCompanyAsync(int companyId);
    }
}
