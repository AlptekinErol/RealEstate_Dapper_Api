using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        [HttpGet("GetContacts")]
        public async Task<IActionResult> GetAllContactAsync()
        {
            var values = await _contactRepository.GetAllContactAsync();
            return Ok(values);
        }

        [HttpGet("GetLast4Contact")]
        public async Task<IActionResult> GetLast4ContactAsync()
        {
            var values = await _contactRepository.GetLast4Contact();
            return Ok(values);
        }
    }
}
