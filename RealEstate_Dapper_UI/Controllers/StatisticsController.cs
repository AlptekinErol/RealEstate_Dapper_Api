using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RealEstate_Dapper_UI.Models.CompositeDashboardViewModel;
using RealEstate_Dapper_UI.Models.EmployeeStatisticsViewModel;
using RealEstate_Dapper_UI.Models.ProductStatisticsViewModel;
using RealEstate_Dapper_UI.UIServices.CompositeDashboardService;
using RealEstate_Dapper_UI.UIServices.EmployeeStatisticServices;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly  IDashboardService _dashboardService;

        public StatisticsController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _dashboardService.GetDashboardData();
            return View(model);
        }
    }
}

