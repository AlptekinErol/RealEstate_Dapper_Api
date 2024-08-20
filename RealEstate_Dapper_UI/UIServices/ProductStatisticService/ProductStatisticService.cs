
namespace RealEstate_Dapper_UI.UIServices.ProductStatisticService
{
    public class ProductStatisticService : IProductStatisticService
    {
        private readonly HttpClient _client;

        public ProductStatisticService(IHttpClientFactory client)
        {
            _client = client.CreateClient();
        }

        public async Task<int> AparmentCount()
        {
            var responseMessage = await _client.GetAsync("https://localhost:44338/api/Statistic/ApartmentCount");
            var intData = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(intData);
            return 2;
        }

        public async Task<decimal> AverageProductPriceByRent()
        {
            var responseMessage = await _client.GetAsync("https://localhost:44338/api/Statistic/AverageProductPriceByRent");
            var decimalValue = await responseMessage.Content.ReadFromJsonAsync<decimal>();
            return decimalValue;
        }

        public async Task<decimal> AverageProductPriceBySale()
        {
            var responseMessage = await _client.GetAsync("https://localhost:44338/api/Statistic/AverageProductPriceBySale");
            var decimalValue = await responseMessage.Content.ReadFromJsonAsync<decimal>();
            return decimalValue;
        }

        public async Task<string?> CityNameByMaxProductCount()
        {
            var responseMessage = await _client.GetAsync("https://localhost:44338/api/Statistic/CityNameByMaxProductCount");
            var stringData = await responseMessage.Content.ReadAsStringAsync();
            return stringData;

        }

        public async Task<int> DifferentCityCount()
        {
            var responseMessage = await _client.GetAsync("https://localhost:44338/api/Statistic/DifferentCityCount");
            var intData = await responseMessage.Content.ReadFromJsonAsync<int>();
            return intData;
        }

        public async Task<decimal> LastProductPrice()
        {
            var responseMessage = await _client.GetAsync("https://localhost:44338/api/Statistic/LastProductPrice");
            var decimalData = await responseMessage.Content.ReadFromJsonAsync<decimal>();
            return decimalData;
        }

        public async Task<int> ProductCount()
        {
            var responseMessage = await _client.GetAsync("https://localhost:44338/api/Statistic/ProductCount");
            var intData = await responseMessage.Content.ReadFromJsonAsync<int>();
            return intData;
        }

    }
}
