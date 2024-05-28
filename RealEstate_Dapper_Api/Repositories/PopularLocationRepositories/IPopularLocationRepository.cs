using RealEstate_Dapper_Api.DTOs.PopularLocationDTOs;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDTO>> GetAllCategoryAsync();
    }
}
