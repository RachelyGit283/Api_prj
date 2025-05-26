using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace TestProject
{
    public class CategoryRepositoryUnitTest
    {
        [Fact]
        public async Task GetCategories_returnsCategories()
        {
            var category1 = new Category { CategoryId = 1, CategoryName = "a" };
            var category2 = new Category { CategoryId = 2, CategoryName = "b" };
            var category3 = new Category { CategoryId = 3, CategoryName = "c" };
            var categories = new List<Category>() { category1, category2, category3 };


            var mockContext = new Mock<StoreDB215085283Context>();
            mockContext.Setup(x => x.Categories).ReturnsDbSet(categories);

            var categoriesData = new CategoriesData(mockContext.Object);

            var res = await categoriesData.GetCategories();

            Assert.Equal(categories, res);

        }
    }
}
