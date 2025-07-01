using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;


namespace My_Store.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        //In all controllers -  notice:
        //1.Clean code - change function name to more descriptive
        //2. Remove commented code or unsuded code
        //3. Methods should return ActionResult to properly handle HTTP responses.

        private readonly ICategoriesServices _categoriesServices;

        public CategoriesController(ICategoriesServices categoriesServices)
        {
            _categoriesServices = categoriesServices;
        }

        // GET: api/<CategoriesController>//
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()//clean code - change function name to more descriptive
        {
            return await _categoriesServices.GetCategories();
        }

        //delete
        // GET api/<CategoriesController>/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // POST api/<CategoriesController>
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }

        // PUT api/<CategoriesController>/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE api/<CategoriesController>/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
