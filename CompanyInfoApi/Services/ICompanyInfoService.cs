using CompanyInfoApi.Models;

namespace CompanyInfoApi.Services
{
    public interface ICompanyInfoService
    {
        Task<CompanyInfo> CreateCompanyInfoAsync(CompanyInfo companyInfo);
        Task<IEnumerable<CompanyInfo>> GetAllCompanyInfosAsync();
    }
}