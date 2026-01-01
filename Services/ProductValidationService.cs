using CatalogAPI.Models;

namespace CatalogAPI.Services
{
    public class ProductValidationService
    {
        public bool IsPremiumProduct(Product product)
        {
            return product.Price >= 100 &&
                   product.Stock > 5 && 
                   (product.Category == CategoryType.Electronics ||
                    product.Category == CategoryType.Office ||
                    product.Category == CategoryType.Industrial);
        }

        public bool QualifiesForPremiumTreatment(Product product)
        {
            return product.Price > 80 && 
                   product.Stock >= 10 &&
                   product.Category != CategoryType.Industrial &&
                   product.SupplierStatus == SupplierStatus.Active;
        }
        public bool IsEligibleForBulkDiscount(Product product)
        {
            return product.IsBusinessProduct &&
                   product.MinimumOrderQuantity >= 10 && 
                   product.SupplierStatus == SupplierStatus.Active &&
                   product.Price > 50; 
        }

        public bool CanPromoteProduct(Product product)
        {
            return product.Price > 25 && product.Price < 1000 &&
                   product.Category != CategoryType.Industrial &&
                   product.Stock > 0; 
        }
    }
}