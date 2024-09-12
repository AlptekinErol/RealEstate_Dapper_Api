using Dapper;
using RealEstate_Dapper_Api.DTOs.ToDoListDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public void CreateToDoList(CreateToDoListDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteToDoList(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultToDoListDTO>> GetAllToDoListAsync()
        {
            string query = "Select * From ToDoList"; // => SQL Query
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDTO>(query); // connection bizim bağlantımızı tutuyor ve QueryAsync bir dapper methodu
                                                                                    // ilgili DTO Parametre olarak verilip ilgili tabloya gerekli query'yi ulaştırıyor
                return values.ToList();
            }
        }

        public Task<GetByIdToDoListDTO> GetToDoListAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateToDoList(UpdateToDoListDTO categoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
