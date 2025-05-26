using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Entities;

namespace Services
{
    public interface IProductsServices
    {
        Task<List<ProductDto>> GetProducts(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}
