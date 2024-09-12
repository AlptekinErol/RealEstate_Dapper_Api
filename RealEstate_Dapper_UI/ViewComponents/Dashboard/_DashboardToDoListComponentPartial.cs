using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.ToDoListDTOs;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardToDoListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _client;

        public _DashboardToDoListComponentPartial(IHttpClientFactory httpClientFactory, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _client = _httpClientFactory.CreateClient();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _client;
            var responseMessage = await client.GetAsync("https://localhost:44338/api/ToDoLists");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();  // await keywordü koymayınca jsonData türü Task oluyor ?
                var values = JsonConvert.DeserializeObject<List<ResultToDoListDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

