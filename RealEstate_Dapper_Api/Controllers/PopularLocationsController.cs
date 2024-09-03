using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.PopularLocationDTOs;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _locationRepository;
        public PopularLocationsController(IPopularLocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        [HttpGet]
        public async Task<IActionResult> PopularLocationList()
        {
            var value = await _locationRepository.GetAllLocationsAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDTO createPopularLocationDTO)
        {
            _locationRepository.CreatePopularLocation(createPopularLocationDTO);
            return Ok("Başarılı bir şekilde veri eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatPopularLocation(UpdatePopularLocationDTO updatePopularLocationDTO)
        {
            _locationRepository.UpdatePopularLocation(updatePopularLocationDTO);
            return Ok("Başarılı bir şekilde veri güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            _locationRepository.DeletePopularLocation(id);
            return Ok("Başarılı bir şekilde veri silinmiştir");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocation(int id)
        {
            var values = await _locationRepository.GetPopularLocation(id);
            return Ok(values);
        }

    }
}
