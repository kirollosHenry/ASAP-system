using ASAP_Application.Contract;
using ASAP_DTO.StockDTO;
using ASAP_Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Application.Services.APIService
{
    public  class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IStockRepo stockRepo;
        //private readonly string _apiKey;
        //private readonly string _apiUrl;

        public ApiService(HttpClient httpClient, IStockRepo _stockRepo)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            stockRepo = _stockRepo;
            //_apiUrl = apiUrl ?? throw new ArgumentNullException(nameof(apiUrl));
            //_apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        public async Task<string> GetDataAsync()
        {
            List<Stock> results = null;
            string responseContent = string.Empty;
            var apiurl = "https://api.polygon.io/v3/reference/splits?cursor=YXA9MjAyNC0wNC0wOSZhcz1UUlVNWSZleGVjdXRpb25fZGF0ZS5sdGU9MjAyNC0wNC0wOSZsaW1pdD0xMCZvcmRlcj1kZXNjJnNvcnQ9ZXhlY3V0aW9uX2RhdGU";
            var apikey = "prpzYUpeBsbHyJop6VzNLPfhpEin9uvE";
            // Set the API key in the request headers
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);

            // Send a GET request to the API endpoint
            HttpResponseMessage response = await _httpClient.GetAsync(apiurl);

            // If the request was successful, read the response content
            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();
                ResponseDTO apiResponse = JsonConvert.DeserializeObject<ResponseDTO>(responseContent);
                if (apiResponse != null)
                {
                    results = apiResponse.results;
                    foreach (var result in results)
                    {

                        Console.WriteLine($"Execution Date: {result.Date}");
                        Console.WriteLine($"Split From: {result.split_from}");
                        Console.WriteLine($"Split To: {result.split_to}");
                        Console.WriteLine($"Ticker: {result.ticker}");
                        Console.WriteLine("----------------------------------");

                    }

                    // Check if the data already exists in the database
                    //var existingData = dbContext.SplitResults.FirstOrDefault(s => s.ExecutionDate == result.ExecutionDate && s.Ticker == result.Ticker);
                   var cool=   await stockRepo.AddRangeAsync(results);
                      

                            // Add the new data to the database
                            //dbContext.SplitResults.Add(result);
             
                }
                Console.WriteLine("Response from API:");
                Console.WriteLine(responseContent);
            }
            else
            {
                // Handle unsuccessful request (e.g., log error, throw exception)
                Console.WriteLine($"Error: {response.StatusCode}");
            }

            return responseContent;
        }
    }
}
