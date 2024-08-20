using Dapper;
using Microsoft.AspNetCore.Components.Forms;
using RealEstate_Dapper_Api.DTOs.EmployeeDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async void CreateEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            string query = "Insert into Employee (Name,Title,Mail,PhoneNumber,ImageUrl,Status) values(@EmployeeName,@Title,@Mail,@PhoneNumber,@ImageUrl,@Status)";
            using (var connection = _context.CreateConnection())
            {
                var paramaters = new DynamicParameters();
                paramaters.Add("@EmployeeName", createEmployeeDTO.Name);
                paramaters.Add("@Title", createEmployeeDTO.Title);
                paramaters.Add("@Mail", createEmployeeDTO.Mail);
                paramaters.Add("@PhoneNumber", createEmployeeDTO.PHoneNumber);
                paramaters.Add("@ImageUrl", createEmployeeDTO.ImageUrl);
                paramaters.Add("@Status", true);
                var values = await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async void DeleteEmployee(int id)
        {
            string query = "Delete from Employee where EmployeeId=@EmployeeId";

            using (var connection = _context.CreateConnection())
            {
                var paramaters = new DynamicParameters();
                paramaters.Add("@EmployeeId", id);
                var values = await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task<List<ResultEmployeeDTO>> GetAllEmployeeAsync()
        {
            string query = " Select * from Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDTO>(query);
                return values.ToList();
            }

        }

        public async Task<GetByIDEmployeeDTO> GetEmployee(int id)
        {
            string query = "Select * from Employee where EmployeeId=@EmployeeId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@EmployeeId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDTO>(query, paramaters);
                return values;
            }

        }

        public async void UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO)
        {
            string query = "Update Employee Set Name=@EmployeeName, Title=@Title ,Mail=@Mail ,PhoneNumber=@PhoneNumber,ImageUrl=@ImageUrl,Status=@Status where EmployeeId=@EmployeeId";
            var parameters = new DynamicParameters();
            parameters.Add("EmployeeName", updateEmployeeDTO.Name);
            parameters.Add("Title", updateEmployeeDTO.Title);
            parameters.Add("Mail", updateEmployeeDTO.Mail);
            parameters.Add("PhoneNumber", updateEmployeeDTO.PHoneNumber);
            parameters.Add("ImageUrl", updateEmployeeDTO.ImageUrl);
            parameters.Add("Status", true);
            parameters.Add("EmployeeId", updateEmployeeDTO.EmployeeID);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.ExecuteAsync(query, parameters);

            }
        }
    }
}
