using CompanyInfoApi.Models;
using CompanyInfoApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace CompanyInfoApi.Controllers
{
    [ApiController]
[Route("api/[controller]")]
[Authorize] ;

    public class CompanyInfoController : Controller
    {
        private readonly ICompanyInfoService _companyInfoService;
        private readonly ICompaniesHouseApiService _companiesHouseApiService;

        public CompanyInfoController(ICompanyInfoService companyInfoService, ICompaniesHouseApiService companiesHouseApiService)
        {
            _companyInfoService = companyInfoService;
            _companiesHouseApiService = companiesHouseApiService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanyInfo([FromBody] CompanyInfo model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCompanyInfo = await _companiesHouseApiService.GetCompanyInfoAsync(model.CompanyNumber);
            if (existingCompanyInfo != null)
            {
                existingCompanyInfo.RetrievedAt = DateTime.UtcNow;
                await _companyInfoService.CreateCompanyInfoAsync(existingCompanyInfo);
                return Ok(existingCompanyInfo);
            }

            return NotFound("Company not found");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyInfo(int id)
        {
            var companyInfo = await _companiesHouseApiService.GetCompanyInfoAsync(id.ToString());
            if (companyInfo == null)
            {
                return NotFound();
            }
            return Ok(companyInfo);
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyInfos()
        {
            var companyInfos = await _companyInfoService.GetAllCompanyInfosAsync();
            return Ok(companyInfos);
        }
    }

}
}
