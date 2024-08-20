namespace RealEstate_Dapper_UI.UIServices.EmployeeStatisticServices
{
    public class EmployeeStatisticService : IEmployeeStatisticService
    {
        private readonly HttpClient _client;

        public EmployeeStatisticService(IHttpClientFactory client)
        {
            _client = client.CreateClient();
        }
        public async Task<string> EmployeeNameByMaxProduct()
        {
            #region 
            var responseMessage = await _client.GetAsync("https://localhost:44338/api/Statistic/EmployeeNameByMaxProduct");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            return jsonData;
            #endregion
        }
        public async Task<string> ActiveEmployeeCounter()
        {
            #region Aktif Çalışan End Point 
            var responseMessage2 = await _client.GetAsync("https://localhost:44338/api/Statistic/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            return jsonData2;
            #endregion
        }


    }
}
