namespace RealEstate_Dapper_Api.DTOs.EmployeeDTOs
{
    public class CreateEmployeeDTO
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Mail { get; set; }
        public string? PHoneNumber { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}

