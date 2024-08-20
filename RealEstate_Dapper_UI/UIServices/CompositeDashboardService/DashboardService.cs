using RealEstate_Dapper_UI.Models.CategoryStatisticsViewModel;
using RealEstate_Dapper_UI.Models.CompositeDashboardViewModel;
using RealEstate_Dapper_UI.Models.EmployeeStatisticsViewModel;
using RealEstate_Dapper_UI.Models.ProductDetailsStatisticsViewModel;
using RealEstate_Dapper_UI.Models.ProductStatisticsViewModel;
using RealEstate_Dapper_UI.UIServices.CategoryStatisticServices;
using RealEstate_Dapper_UI.UIServices.EmployeeStatisticServices;
using RealEstate_Dapper_UI.UIServices.ProductDetailsServices;
using RealEstate_Dapper_UI.UIServices.ProductStatisticService;

namespace RealEstate_Dapper_UI.UIServices.CompositeDashboardService
{
    public class DashboardService : IDashboardService
    {
        private readonly IEmployeeStatisticService _employeeStatisticService;
        private readonly IProductStatisticService _productStatisticService;
        private readonly IProductDetailService _productDetailService;
        private readonly ICategoryService _categoryService;

        public DashboardService(IEmployeeStatisticService employeeStatisticService, IProductStatisticService productStatisticService, IProductDetailService productDetailService, ICategoryService categoryService)
        {
            _employeeStatisticService = employeeStatisticService;
            _productStatisticService = productStatisticService;
            _productDetailService = productDetailService;
            _categoryService = categoryService;
        }

        public async Task<StatisticDashboardCompositeViewModel> GetDashboardData()
        {
            // Composite servis içerisinde istatistik çeken apiler
            

            // Employee Statistics
            var employeeName = await _employeeStatisticService.EmployeeNameByMaxProduct();
            var employeeCount = await _employeeStatisticService.ActiveEmployeeCounter();


            // Product Statistics
            var productCount = await _productStatisticService.ProductCount();
            var lastProductPrice = await _productStatisticService.LastProductPrice();
            var differentCityCount = await _productStatisticService.DifferentCityCount();
            var cityNameByMaxProduct = await _productStatisticService.CityNameByMaxProductCount();
            var averageSalePrice = await _productStatisticService.AverageProductPriceBySale();
            var averageRentPrice = await _productStatisticService.AverageProductPriceByRent();
            var apartmentCount = await _productStatisticService.AparmentCount();


            // Product Details Statistics
            var averageRoomCount = await _productDetailService.AvereageRoomCount();
            var newestBuilding = await _productDetailService.NewestBuildingYear();
            var oldestBuilding = await _productDetailService.OldestBuildingYear();

            // Category Statistics
            var categoryCount = await _categoryService.CategoryCount();
            var deactiveCategory = await _categoryService.DeactiveCategoryCount();
            var categoryNameByMaxProduct = await _categoryService.CategoryNameByMaxProductCount();
            var activeCategory = await _categoryService.ActiveCategoryCount();
           

            return new StatisticDashboardCompositeViewModel
            {
                EmployeeData = new EmployeeStatisticViewModel
                {
                    EmployeeCount = employeeCount,
                    Name = employeeName,
                },
                ProductData = new ProductStatisticViewModel
                {
                    ProductCount = productCount,
                    LastProductPrice = lastProductPrice,
                    DifferentCityCount = differentCityCount,
                    CityNameByMaxProductCount = cityNameByMaxProduct,
                    AverageProductPriceByRent = averageSalePrice,
                    AverageProductPriceBySale = averageRentPrice,
                    ApartmentCount = apartmentCount,
                },
                ProductDetailsData = new ProductDetailsStatisticViewModel
                {
                    OldestBuildingYear = oldestBuilding,
                    NewestBuildingYear = newestBuilding,
                    AvereageRoomCount = averageRoomCount,
                },
                CategoryData = new CategoryStatisticViewModel
                {
                    CategoryCount = categoryCount,
                    ActiveCategoryCount = activeCategory,
                    DeactiveCategoryCount = deactiveCategory,
                    CategoryNameByMaxProductCount = categoryNameByMaxProduct,
                }
            };
        }
    }
}
