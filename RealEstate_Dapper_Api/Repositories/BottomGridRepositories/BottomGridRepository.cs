using Dapper;
using RealEstate_Dapper_Api.DTOs.BottomGridDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;
        public BottomGridRepository(Context context)
        {
            _context = context;
        }
        public void CreateBottomGrid(CreateBottomGridDTO createBottomGridDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteBottomGrid(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultBottomGridDTO>> GetAllBottomGridAsync()
        {
            string query = " Select * from BottomGrid";       // önce dapper için query yazıyoruz 
            using ( var connection = _context.CreateConnection() ) // ado.net gibi connection açıp bu connection içerisinde query yolluyoruz
            {
                var values =  await connection.QueryAsync<ResultBottomGridDTO> (query);   // read işlemlerinde dapper QueryAsync<> methodu ile query yollanıyor
                return values.ToList();  // to list dönüyor
            }
        }

        public Task<GetBottomGridDTO> GetBottomGridAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBottomGrid(UpdateBottomGridDTO updateBottomGridDTO)
        {
            throw new NotImplementedException();
        }
    }
}
