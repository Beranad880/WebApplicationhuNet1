using Microsoft.AspNetCore.Mvc;
using WebApplicationhu03.Repositories;
using WebApplicationhu03.Models;
using System.Threading.Tasks;

namespace WebApplicationhu03.Models
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repo.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repo.AddAsync(product);
            await _repo.SaveAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product updatedProduct)
        {
            if (id != updatedProduct.Id || !ModelState.IsValid)
                return BadRequest();

            var existingProduct = await _repo.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            _repo.Update(updatedProduct);
            await _repo.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingProduct = await _repo.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            _repo.Delete(id);
            await _repo.SaveAsync();

            return NoContent();
        }
    }
}
