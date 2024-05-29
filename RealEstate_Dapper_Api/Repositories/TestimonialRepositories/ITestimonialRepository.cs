using RealEstate_Dapper_Api.DTOs.TestimonialDTOs;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDTO>> GetAllTestimonialAsync();
    }
}
