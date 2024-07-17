using CompanyInfoApi.Data;
using CompanyInfoApi.Models;

namespace CompanyInfoApi.Services
{
    public class CompanyInfoService : ICompanyInfoService
    {
        private readonly ICompanyInfoRepository _repository;
        private readonly ICompaniesHouseApiService _apiService;

        public CompanyInfoService(ICompanyInfoRepository repository, ICompaniesHouseApiService apiService)
        {
            _repository = repository;
            _apiService = apiService;
        }

        public async Task<CompanyInfo> CreateCompanyInfoAsync(CompanyInfo companyInfo)
        {
            var apiCompanyInfo = await _apiService.GetCompanyInfoAsync(companyInfo.CompanyNumber);
            if (apiCompanyInfo != null)
            {
                companyInfo.Address = apiCompanyInfo.Address;
                companyInfo.RetrievedAt = DateTime.Now;

                await _repository.AddAsync(companyInfo);
                return companyInfo;
            }
            throw new Exception("Invalid company number.");
        }

        public async Task<IEnumerable<CompanyInfo>> GetAllCompanyInfosAsync()
        {
            return await _repository.GetAllAsync();
        }
    }

}
