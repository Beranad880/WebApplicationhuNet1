using Microsoft.AspNetCore.Mvc;
using WebApplicationhu03.Repositories;
using WebApplicationhu03.Models; // pokud máš Product v tomto namespace

namespace WebApplicationhu03.Controllers
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
        public IActionResult GetAll()
        {
            var products = _repo.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _repo.GetById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repo.Add(product);
            _repo.Save();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product updatedProduct)
        {
            if (id != updatedProduct.Id || !ModelState.IsValid)
                return BadRequest();

            var existingProduct = _repo.GetById(id);
            if (existingProduct == null)
                return NotFound();

            _repo.Update(updatedProduct);
            _repo.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _repo.GetById(id);
            if (existingProduct == null)
                return NotFound();

            _repo.Delete(id);
            _repo.Save();

            return NoContent();
        }
    }
}
