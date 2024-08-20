namespace RealEstate_Dapper_UI.UIServices.ProductStatisticService
{
    public interface IProductStatisticService
    {
        Task<int> ProductCount();
        Task<decimal> LastProductPrice();
        Task<int> DifferentCityCount();
        Task<string?> CityNameByMaxProductCount();
        Task<decimal> AverageProductPriceBySale();
        Task<decimal> AverageProductPriceByRent();
        Task<int> AparmentCount();

    }
}
