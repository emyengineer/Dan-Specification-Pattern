using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Professional Laptop", Price = 1299.99m, Category = CategoryType.Electronics, Stock = 50, MinimumOrderQuantity = 1, IsBusinessProduct = true, SupplierStatus = SupplierStatus.Active },
                new Product { Id = 2, Name = "Office Chair", Price = 299.99m, Category = CategoryType.Office, Stock = 25, MinimumOrderQuantity = 5, IsBusinessProduct = true, SupplierStatus = SupplierStatus.Active },
                new Product { Id = 3, Name = "Gaming Mouse", Price = 79.99m, Category = CategoryType.Electronics, Stock = 100, MinimumOrderQuantity = 1, IsBusinessProduct = false, SupplierStatus = SupplierStatus.Active },
                new Product { Id = 4, Name = "Industrial Printer", Price = 2499.99m, Category = CategoryType.Industrial, Stock = 10, MinimumOrderQuantity = 1, IsBusinessProduct = true, SupplierStatus = SupplierStatus.Active },
                new Product { Id = 5, Name = "Basic Calculator", Price = 15.99m, Category = CategoryType.Office, Stock = 200, MinimumOrderQuantity = 10, IsBusinessProduct = false, SupplierStatus = SupplierStatus.Active },
                new Product { Id = 6, Name = "Wireless Headphones", Price = 149.99m, Category = CategoryType.Electronics, Stock = 8, MinimumOrderQuantity = 1, IsBusinessProduct = false, SupplierStatus = SupplierStatus.Active },
                new Product { Id = 7, Name = "Desk Lamp", Price = 74.99m, Category = CategoryType.Office, Stock = 22, MinimumOrderQuantity = 1, IsBusinessProduct = false, SupplierStatus = SupplierStatus.Active },
                new Product { Id = 8, Name = "Mechanical Keyboard", Price = 89.99m, Category = CategoryType.Electronics, Stock = 15, MinimumOrderQuantity = 1, IsBusinessProduct = false, SupplierStatus = SupplierStatus.Active },
                new Product { Id = 9, Name = "Conference Phone", Price = 199.99m, Category = CategoryType.Industrial, Stock = 6, MinimumOrderQuantity = 2, IsBusinessProduct = true, SupplierStatus = SupplierStatus.Active },
                new Product { Id = 10, Name = "Coffee Maker", Price = 79.99m, Category = CategoryType.Consumer, Stock = 30, MinimumOrderQuantity = 1, IsBusinessProduct = false, SupplierStatus = SupplierStatus.Active },
                new Product { Id = 11, Name = "Tablet Stand", Price = 45.99m, Category = CategoryType.Office, Stock = 8, MinimumOrderQuantity = 3, IsBusinessProduct = false, SupplierStatus = SupplierStatus.Active },
                new Product { Id = 12, Name = "Smart Monitor", Price = 299.99m, Category = CategoryType.Electronics, Stock = 3, MinimumOrderQuantity = 1, IsBusinessProduct = true, SupplierStatus = SupplierStatus.Inactive  }
            );
        }
    }
}