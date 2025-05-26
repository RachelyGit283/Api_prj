using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<List<Product>> GetProducts()
        {
            try
            {
                return await _StoreDB215085283Context.Products.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new CustomApiException(500, "Error reading products from DB " + ex.Message);
            }
        }
    }
}
