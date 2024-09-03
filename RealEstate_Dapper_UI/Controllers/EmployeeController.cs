using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.CategoryDTOs;
using RealEstate_Dapper_UI.DTOs.EmployeeDTOs;
using System.Net.Http.Json;
using System.Text;

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
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();  // await keywordü koymayınca jsonData türü Task oluyor ?
                var values = JsonConvert.DeserializeObject<List<ResultEmployeeDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            var client = _client;
            var responseMessage = await client.PostAsJsonAsync("https://localhost:44338/api/Employees", createEmployeeDTO); // kodu kısalttık StringContent yazmamıza gerek kalmadı ,ve manuel serialize etmedik
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
      
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var client = _client;
            var responseMessage = await client.DeleteAsync($"https://localhost:44338/api/Employees/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var client = _client;
            var responseMessage = await client.GetAsync($"https://localhost:44338/api/Employees/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateEmployeeDTO>(jsonData);
                return View(values);
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO)
        {

            var client = _client;
            //var responseMessage =await client.PostAsJsonAsync<UpdateCategoryDTO>("https://localhost:44338/api/Categories", updateCategoryDTO); // bu kodu kendim yazdım
            var jsonData = JsonConvert.SerializeObject(updateEmployeeDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44338/api/Employees/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
