using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Models;
using JobSearchAppBackend.ViewModels;

namespace JobSearchAppBackend.Interfaces
{
    public interface ICompanyService
    {
        Task<List<CompanyCreateDTO>> GetAllCompaniesAsync();
        Task<CompanyCreateDTO> GetCompanyByIdAsync(int companyId);
        Task AddCompanyAsync(CompanyCreateDTO company);
        Task UpdateCompanyAsync(CompanyUpdateDTO company);
        Task DeleteCompanyAsync(int companyId);
    }
}
