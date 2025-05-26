using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;

namespace My_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrdersServices _ordersServices;

        public OrdersController(IOrdersServices ordersServices)
        {
            _ordersServices = ordersServices;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            return await _ordersServices.GetOrders();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task Post([FromBody] Order order)
        {
            await _ordersServices.AddOrder(order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
