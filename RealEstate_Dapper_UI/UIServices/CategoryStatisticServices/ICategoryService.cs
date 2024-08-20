namespace RealEstate_Dapper_UI.UIServices.CategoryStatisticServices
{
    public interface ICategoryService
    {
        Task<int> ActiveCategoryCount();
        Task<int> CategoryCount();
        Task<int> DeactiveCategoryCount();
        Task<string> CategoryNameByMaxProductCount();
    }
}
