
namespace RealEstate_Dapper_UI.UIServices.CategoryStatisticServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;

        public CategoryService(IHttpClientFactory client)
        {
            _client = client.CreateClient();
        }

        public async Task<int> ActiveCategoryCount()
        {
            var responseMessage = await _client.GetAsync("https://localhost:44338/api/Statistic/ActiveCategoryCount");
            var intData = await responseMessage.Content.ReadFromJsonAsync<int>();
            return intData;
        }

        public async Task<int> CategoryCount()
        {
            var responseMessage = await _client.GetAsync("https://localhost:44338/api/Statistic/CategoryCount");
            var intData = await responseMessage.Content.ReadFromJsonAsync<int>();
            return intData;
        }

        public async Task<string> CategoryNameByMaxProductCount()
        {
            var responseMessage = await _client.GetAsync("https://localhost:44338/api/Statistic/CategoryNameByMaxProductCount");
            var stringData = await responseMessage.Content.ReadAsStringAsync();
            return stringData;
        }

        public async Task<int> DeactiveCategoryCount()
        {
            var responseMessage = await _client.GetAsync("https://localhost:44338/api/Statistic/DeactiveCategoryCount");
            var intData = await responseMessage.Content.ReadFromJsonAsync<int>();
            return intData;
        }
    }
}
