using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory? _httpClientFactory;

        public _DashboardStatisticComponentPartial(IHttpClientFactory? httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Summary 
            // Burada kurduğum yapı solide ters olabilir fakat aynı yapıyı solide uygun bir şekilde kurduğum istatistik verilerini getirdiğim yapı mevcut
            #region Statistic1-ToplamİlanSayısı
            var client1 =  _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44338/api/Statistic/ProductCount");
            var jsonData = responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData;
            #endregion

            #region Statistic2-EnBaşarılıPersonel
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44338/api/Statistic/EmployeeNameByMaxProductCount");
            var jsonData2 = responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = jsonData2;
            #endregion

            #region Statistic1-İlandakiŞehirSayıları
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44338/api/Statistic/DifferentCityCount");
            var jsonData3 = responseMessage3.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData3;
            #endregion

            #region Statistic4-OrtalamaKiraBedeli
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44338/api/Statistic/AverageProductPriceByRent");
            var jsonData4 = responseMessage4.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceByRent = jsonData4;
            #endregion
            return View();
        }
    }
}
