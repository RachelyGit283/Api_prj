using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
namespace My_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices _productsServices;

        public ProductsController(IProductsServices productsServices)
        {
            _productsServices = productsServices;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return await _productsServices.GetProducts();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
