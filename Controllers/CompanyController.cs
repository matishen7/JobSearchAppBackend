using JobSearchAppBackend.DTOs;
using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using JobSearchAppBackend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace JobSearchAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetCompanies()
        {
            var Companies = await _companyService.GetAllCompaniesAsync();
            return Ok(Companies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var Company = await _companyService.GetCompanyByIdAsync(id);
            if (Company == null)
                return NotFound();

            return Ok(Company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyDTO company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var companyId = await _companyService.AddCompanyAsync(company);
            return CreatedAtAction(nameof(CreateCompany), new { id = companyId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyDTO company)
        {
            var existingCompany = await _companyService.GetCompanyByIdAsync(company.Id);
            if (existingCompany == null)
                return NotFound();

            await _companyService.UpdateCompanyAsync(company);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var existingCompany = await _companyService.GetCompanyByIdAsync(id);
            if (existingCompany == null)
                return NotFound();

            await _companyService.DeleteCompanyAsync(id);
            return NoContent();
        }
    }
}
