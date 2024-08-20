using RealEstate_Dapper_UI.Models.CategoryStatisticsViewModel;
using RealEstate_Dapper_UI.Models.EmployeeStatisticsViewModel;
using RealEstate_Dapper_UI.Models.ProductDetailsStatisticsViewModel;
using RealEstate_Dapper_UI.Models.ProductStatisticsViewModel;


namespace RealEstate_Dapper_UI.Models.CompositeDashboardViewModel
{
    public class StatisticDashboardCompositeViewModel
    {
        public EmployeeStatisticViewModel? EmployeeData { get; set; }
        public ProductStatisticViewModel? ProductData { get; set; }
        public CategoryStatisticViewModel? CategoryData { get; set; }
        public ProductDetailsStatisticViewModel? ProductDetailsData { get; set; }
    }
}
