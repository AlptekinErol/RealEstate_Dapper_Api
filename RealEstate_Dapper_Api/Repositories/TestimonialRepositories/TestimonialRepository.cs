using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_Dapper_Api.DTOs.TestimonialDTOs;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultTestimonialDTO>> GetAllTestimonialAsync()
        {
            string query = "Select*from Testimonial";
            using ( var connection = _context.CreateConnection() )
            {
                var values = await connection.QueryAsync<ResultTestimonialDTO>(query);
                return values.ToList();
            }
        }
    }
}
