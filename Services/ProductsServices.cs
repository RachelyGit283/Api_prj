using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repositories;
namespace Services
{
    public class ProductsServices : IProductsServices
    {
        IProductsData _productsData;
        public ProductsServices(IProductsData productsData)
        {
            _productsData = productsData;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _productsData.GetProducts();
        }
    }
}
