namespace RealEstate_Dapper_UI.Models.ProductStatisticsViewModel
{
    public class ProductStatisticViewModel
    {
        public int ProductCount { get; set; }
        public decimal LastProductPrice { get; set; }
        public int DifferentCityCount { get; set; }
        public string? CityNameByMaxProductCount { get; set; }
        public decimal AverageProductPriceBySale { get; set; }
        public decimal AverageProductPriceByRent { get; set; }
        public int ApartmentCount { get; set; }
    }
}
