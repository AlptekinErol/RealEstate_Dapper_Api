using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_Dapper_Api.DTOs.ContactDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public void CreateContact(CreateContactDTO createContactDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultContactDTO>> GetAllContactAsync()
        {
            string query = "Select * from Contact";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultContactDTO>(query);
                return values.ToList();
            }
        }

        public Task<GetByIdContactDTO> GetByIdContactAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Last4ContactResultDTO>> GetLast4Contact()
        {
            string query = "Select Top(4)* from Contact Order By ContactId desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<Last4ContactResultDTO>(query);
                return values.ToList();
            }
        }
    }
}
