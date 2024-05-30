using RealEstate_Dapper_Api.DTOs.EmployeeDTOs;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDTO>> GetAllEmployeeAsync(); // Category Read imzası 
        void CreateEmployee(CreateEmployeeDTO createEmployeeDTO);
        void UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO);
        void DeleteEmployee(int id);
        Task<GetByIDEmployeeDTO> GetEmployee(int id);
    }   
}
