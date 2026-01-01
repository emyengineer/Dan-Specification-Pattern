using Microsoft.EntityFrameworkCore;
using CatalogAPI.Models;

namespace CatalogAPI.Repositories
{
    public class ProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }

        public async Task<IEnumerable<Product>> GetHighValueProducts()
        {
            return await _context.Products
                .Where(p => p.Price > 150 &&
                           p.Stock >= 1 && 
                           p.Category == CategoryType.Electronics) 
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetPremiumCatalogProducts()
        {
            return await _context.Products
                .Where(p => p.Price >= 75 &&
                           p.Stock > 20 && 
                           (p.Category == CategoryType.Electronics || 
                            p.Category == CategoryType.Office ||
                            p.Category == CategoryType.Industrial) &&
                           p.SupplierStatus == SupplierStatus.Active)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetBusinessCatalogProducts()
        {
            return await _context.Products
                .Where(p => p.IsBusinessProduct &&
                           p.MinimumOrderQuantity >= 1 && 
                           p.SupplierStatus == SupplierStatus.Active &&
                           p.Stock > 0)
                .ToListAsync();
        }
    }
}