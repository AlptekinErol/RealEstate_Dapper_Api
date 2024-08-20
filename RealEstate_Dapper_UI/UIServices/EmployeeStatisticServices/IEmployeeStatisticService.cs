namespace RealEstate_Dapper_UI.UIServices.EmployeeStatisticServices
{
    public interface IEmployeeStatisticService
    {
        Task<string> EmployeeNameByMaxProduct();  // en fazla ürünü olan çalışan
        Task<string> ActiveEmployeeCounter(); // Aktif çalışan sayısı
        
    }
}
