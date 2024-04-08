using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Application.Services.Hangifure
{
    public class JobService : IJobService
    {

        public JobService()
        {
            
        }
        public void DelayedJob()
        {
            Console.WriteLine("Hello from DelayedJob");
        }

        public void ContinuationJob()
        {
            Console.WriteLine("Hello Continuation Job");
        }

       

        public void FireAndForgetJob()
        {
            Console.WriteLine("Hello FireAndForgetJob");
        }

        public void ReccuringJob()
        {
            Console.WriteLine("Hello  Reccuring Job!");
        }
    }
}


//public class Program
//{
//    public static async Task Main()
//    {
//        // Create an HttpClient instance to make the API request
//        using var httpClient = new HttpClient();

//        try
//        {
//            // Make a GET request to the API endpoint
//            var response = await httpClient.GetAsync("https://api.example.com/third-party-api");

//            // Check if the request was successful (HTTP 200-299)
//            if (response.IsSuccessStatusCode)
//            {
//                // Read the response content as a string
//                var content = await response.Content.ReadAsStringAsync();

//                // Process the response data as needed
//                Console.WriteLine(content);
//            }
//            else
//            {
//                // Handle the case when the request was not successful
//                Console.WriteLine($"API request failed with status code: {response.StatusCode}");
//            }
//        }
//        catch (Exception ex)
//        {
//            // Handle any exceptions that occurred during the request
//            Console.WriteLine($"An error occurred: {ex.Message}");
//        }
//    }
//}