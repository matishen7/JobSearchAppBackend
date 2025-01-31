using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Models;
using JobSearchAppBackend.ViewModels;

namespace JobSearchAppBackend.Interfaces
{
    public interface ICompanyService
    {
        Task<List<CompanyDTO>> GetAllCompaniesAsync();
        Task<CompanyDTO> GetCompanyByIdAsync(int companyId);
        Task<int> AddCompanyAsync(CompanyDTO company);
        Task UpdateCompanyAsync(CompanyDTO company);
        Task DeleteCompanyAsync(int companyId);
    }
}
