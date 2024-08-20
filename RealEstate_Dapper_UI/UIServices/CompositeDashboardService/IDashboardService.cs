using RealEstate_Dapper_UI.Models.CompositeDashboardViewModel;

namespace RealEstate_Dapper_UI.UIServices.CompositeDashboardService
{
    public interface IDashboardService
    {
        Task<StatisticDashboardCompositeViewModel> GetDashboardData();
    }
}
