using Dapper;
using RealEstate_Dapper_Api.DTOs.ServiceDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async void CreateService(CreateServiceDTO createServiceDTO)
        {
            string query = "insert into Service (ServiceName,ServiceStatus) values (@serviceName,@serviceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", createServiceDTO.ServiceName);
            parameters.Add("@serviceStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async void DeleteService(int id)
        {
            string query = "Delete From Service Where ServiceID=@serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task<List<ResultServiceDTO>> GetAllServiceAsync()
        {
            string query = "Select * From Service"; // => SQL Query
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDTO>(query); // connection bizim bağlantımızı tutuyor ve QueryAsync bir dapper methodu
                                                                                   // ilgili DTO Parametre olarak verilip ilgili tabloya gerekli query'yi ulaştırıyor
                return values.ToList();
            }
        }

        public async Task<GetServiceByIdDTO> GetServiceAsync(int id)
        {
            string query = "Select * From Service Where ServiceID=@serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetServiceByIdDTO>(query, parameters);
                return values;
            }

        }

        public async void UpdateService(UpdateServiceDTO updateServiceDTO)
        {
            string query = "Update Service Set ServiceName=@serviceName,ServiceStatus=@serviceStatus where ServiceID=@serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", updateServiceDTO.ServiceName);
            parameters.Add("@serviceStatus", updateServiceDTO.ServiceStatus);
            parameters.Add("@serviceID", updateServiceDTO.ServiceID);

            using (var connectiont = _context.CreateConnection())
            {
                await connectiont.ExecuteAsync(query, parameters);
            }

        }
    }
}
