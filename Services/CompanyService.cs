using AutoMapper;
using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using JobSearchAppBackend.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JobSearchAppBackend.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyService> _logger;

        public CompanyService(
            ICompanyRepository companyRepository,
            IMapper mapper,
            ILogger<CompanyService> logger)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<CompanyDTO>> GetAllCompaniesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var companies = await _companyRepository.GetAllCompaniesAsync(cancellationToken);

                return _mapper.Map<List<CompanyDTO>>(companies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving companies.");
                throw new ApplicationException("An error occurred while retrieving companies.", ex);
            }
        }

        public async Task<CompanyDTO> GetCompanyByIdAsync(int companyId, CancellationToken cancellationToken = default)
        {
            try
            {
                var company = await _companyRepository.GetCompanyByIdAsync(companyId, cancellationToken);
                if (company == null)
                    throw new KeyNotFoundException("Company not found.");

                return _mapper.Map<CompanyDTO>(company);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the company.");
                throw new ApplicationException("An error occurred while retrieving the company.", ex);
            }
        }

        public async Task<int> AddCompanyAsync(CompanyDTO companyDTO, CancellationToken cancellationToken = default)
        {
            try
            {
                if (companyDTO == null)
                    throw new ArgumentNullException(nameof(companyDTO));

                var company = _mapper.Map<Company>(companyDTO);
                return await _companyRepository.AddCompanyAsync(company, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the company.");
                throw new ApplicationException("An error occurred while adding the company.", ex);
            }
        }

        public async Task UpdateCompanyAsync(CompanyDTO companyDTO, CancellationToken cancellationToken = default)
        {
            try
            {
                if (companyDTO == null)
                    throw new ArgumentNullException(nameof(companyDTO));

                var existingCompany = await _companyRepository.GetCompanyByIdAsync(companyDTO.Id, cancellationToken);
                if (existingCompany == null)
                    throw new KeyNotFoundException("Company not found.");

                _mapper.Map(companyDTO, existingCompany);
                await _companyRepository.UpdateCompanyAsync(existingCompany, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the company.");
                throw new ApplicationException("An error occurred while updating the company.", ex);
            }
        }

        public async Task DeleteCompanyAsync(int companyId, CancellationToken cancellationToken = default)
        {
            try
            {
                var company = await _companyRepository.GetCompanyByIdAsync(companyId, cancellationToken);
                if (company == null)
                    throw new KeyNotFoundException("Company not found.");

                await _companyRepository.DeleteCompanyAsync(companyId, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the company.");
                throw new ApplicationException("An error occurred while deleting the company.", ex);
            }
        }
    }
}