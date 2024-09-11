using RealEstate_Dapper_Api.DTOs.ProductDTOs;
using RealEstate_Dapper_UI.DTOs.ProductDTOs;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDTO>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategory();
        Task<List<ResultLast5ProductWithCategoryDTO>> GetLast5Product();
        void DealoftheDayActive(int id);
        void DealoftheDayPassive(int id);
    }
}
