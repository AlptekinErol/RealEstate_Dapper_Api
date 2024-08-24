using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.DTOs.WhoWeAreDetailDTOs;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreViewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); // önce request atmak için client gerekli
            var client2 = _httpClientFactory.CreateClient(); // solid çiğneniyo... service bilgileri ekstra çekiliyor


            var responseMessage = await client.GetAsync("https://localhost:44338/api/WhoWeAreDetails"); // client istek atar ve response alır
            var responseMessage2 = await client2.GetAsync("https://localhost:44338/api/Services");

            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode) // eğer response true dönerse işlem yapılacak
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // HTTP Contenti serialize ediyor
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync(); // HTTP Contenti serialize ediyor

                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDTO>>(jsonData); // burada da deserialize ediyoruz
                var value2 = JsonConvert.DeserializeObject<List<ResultServiceDTO>>(jsonData2);

                ViewBag.title = value.Select(x => x.Title).FirstOrDefault();        //first or default ise x ile uyuşanı yakaladığı anda tüm veriyi çekecek
                ViewBag.subtitle = value.Select(x => x.Subtitle).FirstOrDefault();
                ViewBag.description1 = value.Select(x => x.Description1).FirstOrDefault();
                ViewBag.description2 = value.Select(x => x.Description2).FirstOrDefault();
                return View(value2);
            }
            return View();

            // bu sayfa sonlara doğru SOLID ile revize edilmesi gerekiyor!
        }
    }
}
