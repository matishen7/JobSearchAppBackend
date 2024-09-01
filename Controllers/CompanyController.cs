using JobSearchAppBackend.Interfaces;
using JobSearchAppBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IActionResult> CreateCompany([FromBody] Company Company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _companyService.AddCompanyAsync(Company);
            return CreatedAtAction(nameof(GetCompany), new { id = Company.Id }, Company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] Company Company)
        {
            if (id != Company.Id)
                return BadRequest("Company ID mismatch.");

            var existingCompany = await _companyService.GetCompanyByIdAsync(id);
            if (existingCompany == null)
                return NotFound();

            await _companyService.UpdateCompanyAsync(Company);
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
