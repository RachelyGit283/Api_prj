
using Entities;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
    public class ProductsData : IProductsData
    {
        StoreDB215085283Context _StoreDB215085283Context;

        public ProductsData(StoreDB215085283Context storeDB215085283Context)
        {
            _StoreDB215085283Context = storeDB215085283Context;
        }

        public async Task<List<Product>> GetProducts(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            try
            {
                var query = _StoreDB215085283Context.Products.Include(product => product.Category).Where(product =>
                (desc == null ? (true) : (product.Description.Contains(desc)))
                && ((minPrice == null) ? (true) : (product.Price >= minPrice))
                && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
                && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
                    .OrderBy(product => product.Price);

                List<Product> products = await query.ToListAsync();
                return products;

            }
            catch (Exception ex)
            {
                throw new CustomApiException(500, "Error reading products from DB " + ex.Message);
            }
        }
    }
}
