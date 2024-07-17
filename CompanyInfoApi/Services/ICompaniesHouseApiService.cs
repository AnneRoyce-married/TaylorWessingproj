using CompanyInfoApi.Models;

namespace CompanyInfoApi.Services
{
    public interface ICompaniesHouseApiService
    {
        Task<CompanyInfo> GetCompanyInfoAsync(string companyNumber);
    }
}