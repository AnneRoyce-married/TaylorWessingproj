using CompanyInfoApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CompanyInfoApi.Data
{
    public class CompanyInfoApiContext : IdentityDbContext<ApplicationUser>
    {
        public CompanyInfoApiContext (DbContextOptions<CompanyInfoApiContext> options)
            : base(options)
        {
        }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
