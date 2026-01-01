namespace CatalogAPI.Models;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }     // "Professional Laptop"
    public decimal Price { get; set; }            // $1,299.99 
    public CategoryType Category { get; set; }    // Electronics, Office, Industrial, Consumer
    public int Stock { get; set; }                // Available inventory: 50 units
    public int MinimumOrderQuantity { get; set; } // Bulk order requirements: 1
    public bool IsBusinessProduct { get; set; }   // Business customer targeting
    public SupplierStatus SupplierStatus { get; set; } // Active, Inactive, Suspended  
}