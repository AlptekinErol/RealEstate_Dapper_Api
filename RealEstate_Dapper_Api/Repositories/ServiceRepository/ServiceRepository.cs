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

        public void CreateService(CreateServiceDTO createServiceDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteService(int id)
        {
            throw new NotImplementedException();
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

        public Task<GetServiceByIdDTO> GetServiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateService(UpdateServiceDTO updateServiceDTO)
        {
            throw new NotImplementedException();
        }
    }
}
