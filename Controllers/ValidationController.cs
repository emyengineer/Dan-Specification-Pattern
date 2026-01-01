using CatalogAPI.Models;
using CatalogAPI.Repositories;
using CatalogAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidationController : ControllerBase
    {
        private readonly ProductRepository _repository;
        private readonly ProductValidationService _validationService;
        
        public ValidationController(ProductRepository repository, ProductValidationService validationService)
        {
            _repository = repository;
            _validationService = validationService;
        }

        [HttpGet("premium")]
        public async Task<ActionResult<IEnumerable<Product>>> GetValidatedPremiumProducts()
        {
            var allProducts = await _repository.GetProducts().ToListAsync();
            var premiumProducts = allProducts
                .Where(p => _validationService.IsPremiumProduct(p))
                .ToList();
            
            return Ok(premiumProducts);
        }


        [HttpGet("bulk-discount")]
        public async Task<ActionResult<IEnumerable<Product>>> GetBulkDiscountEligibleProducts()
        {
            var allProducts = await _repository.GetProducts().ToListAsync();
            var eligibleProducts = allProducts
                .Where(p => _validationService.IsEligibleForBulkDiscount(p))
                .ToList();
            
            return Ok(eligibleProducts);
        }

        [HttpGet("promotion-eligible")]
        public async Task<ActionResult<IEnumerable<Product>>> GetPromotionEligibleProducts()
        {
            var allProducts = await _repository.GetProducts().ToListAsync();
            var eligibleProducts = allProducts
                .Where(p => _validationService.CanPromoteProduct(p))
                .ToList();
            
            return Ok(eligibleProducts);
        }

    }
}