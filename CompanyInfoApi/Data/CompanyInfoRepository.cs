using CompanyInfoApi.Models;
using Microsoft.EntityFrameworkCore;
namespace CompanyInfoApi.Data
{
  

    public class CompanyInfoRepository : ICompanyInfoRepository
    {
        private readonly CompanyInfoApiContext _context;

        public CompanyInfoRepository(CompanyInfoApiContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CompanyInfo companyInfo)
        {
            _context.Add(companyInfo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CompanyInfo>> GetAllAsync()
        {
            return await _context.CompanyInfos.ToListAsync();
        }
    }
}
