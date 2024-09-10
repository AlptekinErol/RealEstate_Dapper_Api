using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.ProductDTOs;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _client; // client create code became shorter

        public ProductController(IHttpClientFactory httpClientFactory, HttpClient client)
        {
            _httpClientFactory = httpClientFactory;
            _client = _httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var client = _client; //kodu kısalttık...
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _client;
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Categories");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CreateProductDTO>>(jsonData);

            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value=x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.Data = categoryValues;
            return View();
        }
        public async Task<IActionResult> DealoftheDayActive(int id)
        {
            var client = _client; //kodu kısalttık...
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Products/DealoftheDayActive/" +id);
            if (responseMessage.IsSuccessStatusCode)
            {
              
                return RedirectToAction("Index"); 
            }
            return View();
        }

        public async Task<IActionResult> DealoftheDayPassive(int id)
        {
            var client = _client; //kodu kısalttık...
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Products/DealoftheDayPassive/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
