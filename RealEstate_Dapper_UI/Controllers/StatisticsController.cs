using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RealEstate_Dapper_UI.Models.EmployeeStatisticsViewModel;
using RealEstate_Dapper_UI.UIServices.EmployeeStatisticServices;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IEmployeeStatisticService _employeeStatisticService;
        public StatisticsController(IEmployeeStatisticService employeeStatisticService)
        {
            _employeeStatisticService = employeeStatisticService;
        }
        public async Task<IActionResult> Index()
        {
                    // Employee Statistic part
            var employeeCount = await _employeeStatisticService.ActiveEmployeeCounter();
            var employeeName = await _employeeStatisticService.EmployeeNameByMaxProduct();

            var model = new EmployeStatisticViewModel
            {
                Name = employeeName,
                EmployeeCount = employeeCount
            };
            return View(model);

            

        }
    }
}

