using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.DTOs.ProductDTOs;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategory();
            return Ok(values);
        }

        [HttpGet("DealoftheDayActive/{id}")]
        public async Task<IActionResult> DealoftheDayActive(int id)
        {
            _productRepository.DealoftheDayActive(id);
            return Ok("ilan günün fırsatlarına eklendi");
        }

        [HttpGet("DealoftheDayPassive/{id}")]
        public async Task<IActionResult> DealoftheDayPassive(int id)
        {
            _productRepository.DealoftheDayPassive(id);
            return Ok("ilan günün fırsatlarından çıkarıldı");
        }
    }
}
