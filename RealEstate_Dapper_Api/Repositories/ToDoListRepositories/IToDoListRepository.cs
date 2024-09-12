using RealEstate_Dapper_Api.DTOs.ToDoListDTOs;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDTO>> GetAllToDoListAsync(); // Category Read imzası 
        void CreateToDoList(CreateToDoListDTO categoryDTO);
        void UpdateToDoList(UpdateToDoListDTO categoryDTO);
        void DeleteToDoList(int id);
        Task<GetByIdToDoListDTO> GetToDoListAsync(int id);
    }
}
