using Dapper;
using RealEstate_Dapper_Api.DTOs.PopularLocationDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPopularLocationDTO>> GetAllCategoryAsync()
        {
            string query = "Select * from PopularLocation"; // query
            using ( var connection = _context.CreateConnection() )
            {
                var values = await connection.QueryAsync<ResultPopularLocationDTO>(query);
                return values.ToList();
            }
        }
    }
}
