using CompanyInfoApi.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace CompanyInfoApi.Services
{
    public class CompaniesHouseApiService : ICompaniesHouseApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public CompaniesHouseApiService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task<CompanyInfo> GetCompanyInfoAsync(string companyNumber)
        {
            var apiKey = _configuration["CompaniesHouseApiKey"];
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes(apiKey))}");
            var response = await client.GetAsync($"https://api.company-information.service.gov.uk/company/{companyNumber}");

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var companyData = await JsonSerializer.DeserializeAsync<CompanyInfo>(responseStream);
                return companyData;
            }
            return null;
        }
    }
}
