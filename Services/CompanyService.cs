using AutoMapper;
using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using JobSearchAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSearchAppBackend.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository,
            IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await _companyRepository.GetAllCompaniesAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int CompanyId)
        {
            return await _companyRepository.GetCompanyByIdAsync(CompanyId);
        }

        public async Task AddCompanyAsync(CompanyDTO companyDTO)
        {
            var company = _mapper.Map<Company>(companyDTO);
            await _companyRepository.AddCompanyAsync(company);
        }

        public async Task UpdateCompanyAsync(CompanyDTO companyDTO)
        {
            var company = _mapper.Map<Company>(companyDTO);
            await _companyRepository.UpdateCompanyAsync(company);
        }

        public async Task DeleteCompanyAsync(int CompanyId)
        {
            await _companyRepository.DeleteCompanyAsync(CompanyId);
        }
    }
}
