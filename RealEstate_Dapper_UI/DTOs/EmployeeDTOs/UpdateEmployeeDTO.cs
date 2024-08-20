﻿namespace RealEstate_Dapper_UI.DTOs.EmployeeDTOs
{
    public class UpdateEmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public string? Title { get; set; }
        public string? Mail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}

