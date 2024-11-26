using System.Net.Http;
using System.Net.Http.Json;
using TestTaskWPF;
using TestTaskWPF.Models;

namespace CoinCapApi
{ 
    public class ApiService : IApiService
    {
        private const string url = "https://api.coincap.io/v2/";

        private readonly HttpClient client = new();

        public async Task<CoinsResponse> GetCoinsAsync(int count)
        {
            string path = $"{url}assets?limit={count}";

            HttpResponseMessage response = await client.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                return new CoinsResponse();
            }          

            return await response.Content.ReadFromJsonAsync<CoinsResponse>() ?? new CoinsResponse();
        }

        public async Task<MarketsResponse> GetMarketsAsync(string coinId, int count)
        {
            string path = $"{url}assets/{coinId}/markets?limit={count}";

            HttpResponseMessage response = await client.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                return new MarketsResponse();
            }

            return await response.Content.ReadFromJsonAsync<MarketsResponse>() ?? new MarketsResponse();
        }
    }
}
