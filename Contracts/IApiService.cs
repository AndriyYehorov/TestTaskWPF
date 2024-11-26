using TestTaskWPF.Models;

namespace TestTaskWPF
{
    public interface IApiService
    {
        public Task<CoinsResponse> GetCoinsAsync(int count);

        public Task<CoinsResponse> GetCoinsByNameAsync(string name, int count);

        public Task<MarketsResponse> GetMarketsAsync(string coinId, int count);
        
    }
}