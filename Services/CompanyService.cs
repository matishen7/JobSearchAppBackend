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

        public async Task<List<CompanyCreateDTO>> GetAllCompaniesAsync()
        {
            var companies = await _companyRepository.GetAllCompaniesAsync();

            var companyDtos = _mapper.Map<List<CompanyCreateDTO>>(companies);
            return companyDtos;
        }

        public async Task<CompanyCreateDTO> GetCompanyByIdAsync(int CompanyId)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(CompanyId);
            if (company == null)
            {
                return null;
            }

            var companyDto = _mapper.Map<CompanyCreateDTO>(company);
            return companyDto;
        }

        public async Task AddCompanyAsync(CompanyCreateDTO companyDTO)
        {
            var company = _mapper.Map<Company>(companyDTO);
            await _companyRepository.AddCompanyAsync(company);
        }

        public async Task UpdateCompanyAsync(CompanyUpdateDTO companyDTO)
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
