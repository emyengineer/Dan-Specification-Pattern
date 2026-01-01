using CatalogAPI.Models;
using CatalogAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _repository;
        
        public ProductsController(ProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _repository.GetProducts().ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repository.GetProducts()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("by-category/{category}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(CategoryType category)
        {
            var products = await _repository.GetProducts()
                .Where(p => p.Category == category)
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("by-price-range")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByPriceRange(
            [FromQuery] decimal minPrice, 
            [FromQuery] decimal maxPrice)
        {
            var products = await _repository.GetProducts()
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("in-stock")]
        public async Task<ActionResult<IEnumerable<Product>>> GetInStockProducts()
        {
            var products = await _repository.GetProducts()
                .Where(p => p.Stock > 0)
                .ToListAsync();

            return Ok(products);
        }
    }
}