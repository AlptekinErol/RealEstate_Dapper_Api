﻿namespace RealEstate_Dapper_Api.DTOs.PopularLocationDTOs
{
    public class UpdatePopularLocationDTO
    {
        public int LocationID { get; set; }
        public string? CityName { get; set; }
        public string? ImageURL { get; set; }
    }
}
