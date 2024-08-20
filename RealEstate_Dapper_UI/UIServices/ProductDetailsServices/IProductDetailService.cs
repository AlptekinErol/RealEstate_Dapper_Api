namespace RealEstate_Dapper_UI.UIServices.ProductDetailsServices
{
    public interface IProductDetailService
    {
        Task<string?> NewestBuildingYear();
        Task<int> AvereageRoomCount();
        Task<string?> OldestBuildingYear();
    }
}
