using System.Net.Http;
using System.Net.Http.Json;
using TestTaskWPF;
using TestTaskWPF.Models;

namespace CoinCapApi
{ 
    public class ApiService : IApiService
    {
        private const string url = "https://api.coincap.io/v2/";

        public async Task<ApiResponse> GetCoinsAsync(int count)
        {
            string path = $"{url}assets?limit={count}";

            using HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                return new ApiResponse();
            }          

            return await response.Content.ReadFromJsonAsync<ApiResponse>() ?? new ApiResponse();
        }
    }
}
