namespace RealEstate_Dapper_Api.DTOs.CategoryDTOs
{
    public class GetByIDCategoryDTO
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
    }
}
