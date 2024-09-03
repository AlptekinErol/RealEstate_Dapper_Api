using RealEstate_Dapper_Api.DTOs.BottomGridDTOs;


namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDTO>> GetAllBottomGridAsync(); // Bottom Grid read imza
        void CreateBottomGrid(CreateBottomGridDTO createBottomGridDTO);
        void UpdateBottomGrid (UpdateBottomGridDTO updateBottomGridDTO);
        void DeleteBottomGrid(int id);
        Task<GetBottomGridDTO> GetBottomGrid(int id);
    }
}
