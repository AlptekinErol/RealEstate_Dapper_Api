using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.ToDoListDTOs;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ToDoListsController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListsController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ToDoListList()
        {
            var values = await _toDoListRepository.GetAllToDoListAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewToDoList(CreateToDoListDTO createToDoListDTO)
        {
            _toDoListRepository.CreateToDoList(createToDoListDTO);
            return Ok("Yeni ToDoList bilgileri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateToDoList(UpdateToDoListDTO updateToDoListDTO)
        {
            _toDoListRepository.UpdateToDoList(updateToDoListDTO);
            return Ok("güncellenme başarılı bir şekilde yapıldı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoList(int id)
        {
            _toDoListRepository.DeleteToDoList(id);
            return Ok("Kayıt silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoListById(int id)
        {
            var values = await _toDoListRepository.GetToDoListAsync(id);
            return Ok(values);
        }
    }
}

