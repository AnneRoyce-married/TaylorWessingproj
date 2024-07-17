using CompanyInfoApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CompanyInfoApi.Services
{
    public class CompanyService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CompanyService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }


        public async Task<List<CompanyInfo>> GetCompanyList(string companyName)
        {
            var apiKey = _configuration["CompaniesHouseApiKey"];
            var requestUri = $"https://api.company-information.service.gov.uk/search/companies?q={companyName}";

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {apiKey}");

            var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var searchResults = JsonConvert.DeserializeObject<SearchResults>(content);

            var companyList = new List<CompanyInfo>();

            foreach (var item in searchResults.items)
            {
                var companyDetails = await GetCompanyDetails(item.company_number);
                companyList.Add(companyDetails);
            }

            return companyList;
        }
        public async Task<CompanyInfo?> GetCompanyInfo(string companyName)
        {
            var apiKey = _configuration["CompaniesHouseApiKey"];
            var requestUri = $"https://api.company-information.service.gov.uk/search/companies?q={companyName}";

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {apiKey}");

            var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var searchResults = JsonConvert.DeserializeObject<SearchResults>(content);

            if (searchResults.items.Length > 0)
            {
                var companyNumber = searchResults.items[0].company_number;
                return await GetCompanyDetails(companyNumber);
            }

            return null;
        }

        private async Task<CompanyInfo> GetCompanyDetails(string companyNumber)
        {
            var requestUri = $"https://api.company-information.service.gov.uk/company/{companyNumber}";

            var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CompanyInfo>(content);
        }
    }

    public class SearchResults
    {
        public SearchResultItem[] items { get; set; }
    }

    public class SearchResultItem
    {
        public string company_number { get; set; }
    }
}
