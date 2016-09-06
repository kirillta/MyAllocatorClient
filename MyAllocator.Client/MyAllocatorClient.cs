using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MyAllocator.Client.Models;
using Newtonsoft.Json;

namespace MyAllocator.Client
{
    public class MyAllocatorClient
    {
        public MyAllocatorClient()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            _client = new HttpClient {BaseAddress = new Uri("https://api.myallocator.com/pms/v201408/json/")};
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<IMyAllocatorResult> GetHelloWorldResult(HelloWorld parameter)
        {
            var address = ApiAddresses.HelloWorld.ToString();
            var requestBody = JsonConvert.SerializeObject(parameter);

            var response = await GetResponse(address, requestBody);
            var result = JsonConvert.DeserializeObject<HelloWorldResult>(response);

            return result;
        }


        private async Task<string> GetResponse(string address, string requestBody)
        {
            var result = string.Empty;

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, address);
                request.Content = new FormUrlEncodedContent(new[] {new KeyValuePair<string, string>("json", requestBody)});

                var response = await _client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                    result = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                //TODO: this will be depend on handling policy.
                Console.WriteLine(e);
                throw;
            }

            return result;
        }


        private readonly HttpClient _client;
    }
}
