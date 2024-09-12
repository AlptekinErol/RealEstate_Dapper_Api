using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.ToDoListDTOs;

namespace RealEstate_Dapper_UI.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _client;

        public ToDoListController(IHttpClientFactory httpClientFactory, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _client = _httpClientFactory.CreateClient();
        }
        public async Task<IActionResult> Index()
        {
            var client = _client;
            var responseMessage = await client.GetAsync("https://localhost:44338/api/ToDoList");
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
