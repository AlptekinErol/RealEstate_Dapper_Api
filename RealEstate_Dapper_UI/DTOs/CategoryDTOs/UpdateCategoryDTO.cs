namespace RealEstate_Dapper_UI.DTOs.CategoryDTOs
{
    public class UpdateCategoryDTO
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
    }
}
