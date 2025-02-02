using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Models;
using JobSearchAppBackend.ViewModels;

namespace JobSearchAppBackend.Interfaces
{
    public interface ICompanyService
    {
        Task<List<CompanyDTO>> GetAllCompaniesAsync(CancellationToken cancellationToken = default);
        Task<CompanyDTO> GetCompanyByIdAsync(int companyId, CancellationToken cancellationToken = default);
        Task<int> AddCompanyAsync(CompanyDTO company, CancellationToken cancellationToken = default);
        Task UpdateCompanyAsync(CompanyDTO company, CancellationToken cancellationToken = default);
        Task DeleteCompanyAsync(int companyId, CancellationToken cancellationToken = default);
    }
}
