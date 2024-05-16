using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.CategoryDTOs;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryRepository.GetAllCategoryAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            _categoryRepository.CreateCategory(createCategoryDTO);
            return Ok("Kategory başarılı bir şekilde eklendi"); // 200 lü komut dönebilir buraya istersek if atarak 200 veya hata kodu döndürebiliriz (404vs)
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return Ok("Kategori başarılı bir şekilde silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            _categoryRepository.UpdateCategory(updateCategoryDTO);
            return Ok("Kategori başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}")] //link parametresi
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var value =_categoryRepository.GetCategoryAsync(id);
            return Ok(value);
        }
    }
}
