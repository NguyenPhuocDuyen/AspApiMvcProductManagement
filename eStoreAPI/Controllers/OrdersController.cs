using BusinessObject;
using DataAccess.Repository.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderRepository repository = new OrderRepository();
        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders() => repository.GetOrders();

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var p = repository.GetOrderById(id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        [HttpPost]
        public IActionResult PostOrder(Order order)
        {
            repository.SaveOrder(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var p = repository.GetOrderById(id);
            if (p == null)
            {
                return NotFound();
            }
            repository.DeleteOrder(p);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, Order order)
        {
            var temp = repository.GetOrderById(id);
            if (temp == null)
            {
                return NotFound();
            }
            repository.UpdateOrder(order);
            return NoContent();
        }
    }
}
