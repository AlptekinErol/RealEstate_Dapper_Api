﻿namespace RealEstate_Dapper_Api.DTOs.ProductDTOs
{
    public class ResultProductWithCategoryDTO
    {
        public int ProductId { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Name{ get; set; }
    }
}