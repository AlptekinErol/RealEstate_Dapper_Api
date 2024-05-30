namespace RealEstate_Dapper_UI.DTOs.EmployeeDTOs
{
    public class GetByIDEmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public string? Title { get; set; }
        public string? Mail { get; set; }
        public string? PHoneNumber { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
