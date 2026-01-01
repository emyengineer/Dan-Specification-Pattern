using CatalogAPI.Models;
using CatalogAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ProductRepository _repository;
        
        public CatalogController(ProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("business")]
        public async Task<ActionResult<IEnumerable<Product>>> GetBusinessCatalog()
        {
            var products = (await _repository.GetBusinessCatalogProducts())
                .Where(p => p.MinimumOrderQuantity >= 5)
                .ToList();

            return Ok(products);
        }

        [HttpGet("promotional")]
        public async Task<ActionResult<IEnumerable<Product>>> GetPromotionalCatalog()
        {
            var products = await _repository.GetProducts()
                .Where(p => p.Price >= 50 && p.Price <= 500 &&
                           p.Category != CategoryType.Industrial)
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("featured")]
        public async Task<ActionResult<IEnumerable<Product>>> GetFeaturedProducts()
        {
            var products = await _repository.GetProducts()
                .Where(p => p.Price > 75 && 
                           p.Stock > 15 && 
                           p.SupplierStatus == SupplierStatus.Active &&
                           (p.Category == CategoryType.Electronics || 
                            p.Category == CategoryType.Office ||
                            p.Category == CategoryType.Consumer))
                .ToListAsync();

            return Ok(products);
        }

    }
}