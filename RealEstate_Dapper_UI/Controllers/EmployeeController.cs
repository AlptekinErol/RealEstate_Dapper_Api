using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.CategoryDTOs;
using RealEstate_Dapper_UI.DTOs.EmployeeDTOs;

namespace RealEstate_Dapper_UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _client;

        public EmployeeController(IHttpClientFactory httpClientFactory, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _client = _httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _client;
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Employees");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();  // await keywordü koymayınca jsonData türü Task oluyor ?
                var values = JsonConvert.DeserializeObject<List<ResultEmployeeDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
