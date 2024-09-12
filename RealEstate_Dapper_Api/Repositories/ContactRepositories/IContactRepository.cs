using RealEstate_Dapper_Api.DTOs.ContactDTOs;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDTO>> GetAllContactAsync();
        Task<List<Last4ContactResultDTO>> GetLast4Contact();
        void CreateContact(CreateContactDTO createContactDTO);
        void DeleteContact(int id);
        Task<GetByIdContactDTO> GetByIdContactAsync(int id);
    }
}
