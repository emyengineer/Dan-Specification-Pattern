using CatalogAPI.Models;
using CatalogAPI.Repositories;
using CatalogAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PremiumProductsController : ControllerBase
    {
        private readonly ProductRepository _repository;
        private readonly ProductValidationService _validationService;
        
        public PremiumProductsController(ProductRepository repository, ProductValidationService validationService)
        {
            _repository = repository;
            _validationService = validationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetPremiumProducts()
        {
            var products = await _repository.GetProducts()
                .Where(p => p.Price > 50 &&
                           p.Stock > 5 && 
                           (p.Category == CategoryType.Electronics || 
                            p.Category == CategoryType.Office))
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("electronics-only")]
        public async Task<ActionResult<IEnumerable<Product>>> GetElectronicsOnlyProducts()
        {
            var products = await _repository.GetHighValueProducts();
            return Ok(products);
        }

        [HttpGet("multi-category")]
        public async Task<ActionResult<IEnumerable<Product>>> GetMultiCategoryProducts()
        {
            var products = await _repository.GetPremiumCatalogProducts();
            return Ok(products);
        }

    }
}