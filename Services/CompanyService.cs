using AutoMapper;
using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using JobSearchAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        public async Task<List<CompanyDTO>> GetAllCompaniesAsync()
        {
            var companies = await _companyRepository.GetAllCompaniesAsync();

            var companyDtos = _mapper.Map<List<CompanyDTO>>(companies);
            return companyDtos;
        }

        public async Task<CompanyDTO> GetCompanyByIdAsync(int CompanyId)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(CompanyId);
            var companyDto = _mapper.Map<CompanyDTO>(company);
            return companyDto;
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
