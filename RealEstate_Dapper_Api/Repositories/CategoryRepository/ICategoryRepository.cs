using RealEstate_Dapper_Api.DTOs.CategoryDTOs;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDTO>> GetAllCategoryAsync(); // Category Read imzası 
        void CreateCategory(CreateCategoryDTO categoryDTO);
        void UpdateCategory(UpdateCategoryDTO categoryDTO);
        void DeleteCategory(int id);
        Task<GetByIDCategoryDTO> GetCategoryAsync(int id);
        
    }
}
