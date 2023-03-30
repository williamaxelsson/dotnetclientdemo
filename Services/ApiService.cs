using System;
using System.Net.Http;
using System.Threading.Tasks;
using dotnetClientDemo.Models;

namespace dotnetClientDemo.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        // private MyModel _httpResponse = new MyModel();

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetDataFromApi( string url, string path) 
        {

            try
            {
                var response = await _httpClient.GetAsync($"{url}{path}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
                
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error retrieving data from API: {ex.Message}");
            }
        }
    }
}
