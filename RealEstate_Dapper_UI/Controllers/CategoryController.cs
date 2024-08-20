using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.CategoryDTOs;
using System.Text;
using System.Text.Json.Serialization;

namespace RealEstate_Dapper_UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _client;

        public CategoryController(IHttpClientFactory httpClientFactory, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _client = _httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var client = _client; // client oluşturuldu
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Categories"); // request uri
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // veriyi json olarak okuyoruz
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCAtegory()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            var client = _client;
            var jsonData = JsonConvert.SerializeObject(createCategoryDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");  // StringContent sınıfı HTTP base content tutuyor yani api işlemlerinde kullanacağımız
            var responseMessage = await client.PostAsync("https://localhost:44338/api/Categories", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");  // 200 halinde redirect 
            }
            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _client;
            var responseMessage = await client.DeleteAsync($"https://localhost:44338/api/Categories/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _client;
            var responseMessage = await client.GetAsync($"https://localhost:44338/api/Categories/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDTO>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            var client = _client;
            //var responseMessage =await client.PostAsJsonAsync<UpdateCategoryDTO>("https://localhost:44338/api/Categories", updateCategoryDTO); // bu kodu kendim yazdım
            var jsonData = JsonConvert.SerializeObject(updateCategoryDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44338/api/Categories/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
