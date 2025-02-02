using JobSearchAppBackend.Models;
using System.Threading;

namespace JobSearchAppBackend.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllCompaniesAsync(CancellationToken cancellationToken = default);
        Task<Company> GetCompanyByIdAsync(int companyId,CancellationToken cancellationToken = default);
        Task<int> AddCompanyAsync(Company company, CancellationToken cancellationToken = default);
        Task UpdateCompanyAsync(Company company, CancellationToken cancellationToken = default);
        Task DeleteCompanyAsync(int companyId, CancellationToken cancellationToken = default);
    }
}
