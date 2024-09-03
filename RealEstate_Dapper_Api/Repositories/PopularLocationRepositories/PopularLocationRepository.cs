using Dapper;
using RealEstate_Dapper_Api.DTOs.PopularLocationDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Runtime.InteropServices;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async void CreatePopularLocation(CreatePopularLocationDTO createPopularLocationDTO)
        {
            string query = "Insert into PopularLocation (CityName,ImageURL) values (@cityName,@imageURL)";

            var parameters = new DynamicParameters();
            parameters.Add("@cityName", createPopularLocationDTO.CityName);
            parameters.Add("@imageURL", createPopularLocationDTO.ImageURL);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters); // Dapper ExecuteASync methodu önce SQL Query'si ardından parametreleri kabul ediyor yani imzasında belirli bir sıra mevcut
            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = "Delete from PopularLocation where LocationID=@locationId";
            var parameters = new DynamicParameters();
            parameters.Add("@locationId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultPopularLocationDTO>> GetAllLocationsAsync()
        {
            string query = "Select * from PopularLocation"; // query
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdPopularLocationDTO> GetPopularLocation(int id)
        {
            string query = "Select * from PopularLocation Where LocationID=@locationId";
            var parameters = new DynamicParameters();
            parameters.Add("@locationId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDTO>(query, parameters);
                return values;
            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationDTO updatePopularLocationDTO)
        {
            string query = "Update PopularLocation Set CityName=@cityName , ImageURL=@imageURL where LocationID = @locationId";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", updatePopularLocationDTO.CityName);
            parameters.Add("@imageURL", updatePopularLocationDTO.ImageURL);
            parameters.Add("@locationId", updatePopularLocationDTO.LocationID);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
