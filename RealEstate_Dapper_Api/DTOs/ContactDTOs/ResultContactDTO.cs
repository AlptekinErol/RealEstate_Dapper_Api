﻿namespace RealEstate_Dapper_Api.DTOs.ContactDTOs
{
    public class ResultContactDTO
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public DateTime SendDate { get; set; }
    }
}