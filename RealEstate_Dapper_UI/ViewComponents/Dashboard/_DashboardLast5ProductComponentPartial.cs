using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.ProductDTOs;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardLast5ProductComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _client; // client create code became shorter

        public _DashboardLast5ProductComponentPartial(IHttpClientFactory httpClientFactory, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _client = _httpClientFactory.CreateClient();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _client; //kodu kısalttık...
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Products/Last5ProductList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast5ProductWithCategoryDTO>>(jsonData);
                return View(values);
            }
            return View();
            
        }
    }
}
