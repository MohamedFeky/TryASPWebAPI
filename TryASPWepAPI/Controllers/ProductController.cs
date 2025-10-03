using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryASPWepAPI.Models;
using TryASPWepAPI.Repositories;

namespace TryASPWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repo.GetAllAsync();
            return Ok(products);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]Product product)
        {
            await _repo.CreateProductAsync(product);
            await _repo.SaveAsync();

            return CreatedAtAction(nameof(GetById), new {id=product.Id}, product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, Product productFromRequest)
        {
            if (id != productFromRequest.Id) return BadRequest();
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null ) return NotFound();

            existing.Name = productFromRequest.Name;
            existing.Description = productFromRequest.Description;
            existing.Price = productFromRequest.Price;
            existing.Quantity = productFromRequest.Quantity;
            existing.CategoryId = productFromRequest.CategoryId;

            await _repo.UpdateProductAsync(existing);
            await _repo.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _repo.DeleteProductAsync(id);
            await _repo.SaveAsync();
            return NoContent();
        }

    }
}
