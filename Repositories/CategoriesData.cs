
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class CategoriesData : ICategoriesData
    {
        StoreDB215085283Context _StoreDB215085283Context;

        public CategoriesData(StoreDB215085283Context storeDB215085283Context)
        {
            _StoreDB215085283Context = storeDB215085283Context;
        }

        public async Task<List<Category>> GetCategories()
        {
            try
            {
                return await _StoreDB215085283Context.Categories.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new CustomApiException(500, "Error reading categories from DB " + ex.Message);
            }
        }
    }
}
