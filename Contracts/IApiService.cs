using TestTaskWPF.Models;

namespace TestTaskWPF
{
    public interface IApiService
    {
        public Task<ApiResponse> GetCoinsAsync(int count);
    }
}