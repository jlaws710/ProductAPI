using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var products = await _productRepo.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var productId = await _productRepo.GetByIdAsync(id);
                return Ok(productId);
            }
            catch (KeyNotFoundException) 
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            await _productRepo.AddAsync(product);

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Product product)
        {
            try
            {
                await _productRepo.UpdateAsync(product);

                return NoContent();
            } catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productRepo.DeleteAsync(id);

                return NoContent();
            } catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
