﻿namespace RealEstate_Dapper_UI.DTOs.ProductDTOs
{
    public class ResultProductDTO
    {
        public int ProductId { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Name { get; set; }
        public string? Coverimage { get; set; }
        public string? Type { get; set; }
        public string? Address { get; set; }
        public bool DealoftheDay { get; set; }
    }
}
