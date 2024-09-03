using RealEstate_Dapper_Api.DTOs.PopularLocationDTOs;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDTO>> GetAllLocationsAsync();
        void CreatePopularLocation(CreatePopularLocationDTO createPopularLocationDTO);
        void UpdatePopularLocation(UpdatePopularLocationDTO updatePopularLocationDTO);
        void DeletePopularLocation(int id);
        Task<GetByIdPopularLocationDTO> GetPopularLocation(int id);


    }
}
