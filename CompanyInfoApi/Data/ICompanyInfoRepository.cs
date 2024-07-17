using CompanyInfoApi.Models;

namespace CompanyInfoApi.Data
{
 
        public interface ICompanyInfoRepository
        {
            Task AddAsync(CompanyInfo companyInfo);
            Task<IEnumerable<CompanyInfo>> GetAllAsync();
        }

    
}