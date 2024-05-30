using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.EmployeeDTOs;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
           var values =await _employeeRepository.GetAllEmployeeAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
             _employeeRepository.CreateEmployee(createEmployeeDTO);
            return Ok("Yeni çalışan bilgileri eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO)
        {
            _employeeRepository.UpdateEmployee(updateEmployeeDTO);
            return Ok("güncellenme başarılı bir şekilde yapıldı");
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return Ok("Kayıt silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var values = await _employeeRepository.GetEmployee(id);
            return Ok(values);
        }
    }
}
