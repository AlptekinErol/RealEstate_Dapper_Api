
namespace RealEstate_Dapper_UI.UIServices.ProductDetailsServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _client;

        public ProductDetailService(IHttpClientFactory client)
        {
            _client = client.CreateClient();
        }

        public async Task<int> AvereageRoomCount()
        {
            var responseMessage = await _client.GetAsync("https://localhost:44338/api/Statistic/AverageRoomCount");
            var intData = await responseMessage.Content.ReadFromJsonAsync<int>();
            return intData;
        }

        public async Task<string?> NewestBuildingYear()
        {
            var responseMessage = await _client.GetAsync("https://localhost:44338/api/Statistic/NewestBuildingYear");
            var stringData = await responseMessage.Content.ReadAsStringAsync();
            return stringData;
        }

        public async Task<string?> OldestBuildingYear()
        {
            var responseMessage = await _client.GetAsync("https://localhost:44338/api/Statistic/OldestBuildingYear");
            var stringData = await responseMessage.Content.ReadAsStringAsync();
            return stringData;
        }
    }
}
