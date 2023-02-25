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
    public class OrderDetailsController : ControllerBase
    {
        private IOrderDetailRepository repository = new OrderDetailRepository();
        // GET: api/<OrderDetailsController>
        [HttpGet]
        public ActionResult<IEnumerable<OrderDetail>> GetOrderDetails() => repository.GetOrderDetails();

        // GET api/<OrderDetailsController>/5/6
        [HttpGet("{propId}/{orderId}")]
        public ActionResult<OrderDetail> Get(int propId, int orderId)
        {
            var p = repository.GetOrderDetailById(propId, orderId);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        [HttpPost]
        public IActionResult PostOrderDetail(OrderDetail orderDetail)
        {
            repository.SaveOrderDetail(orderDetail);
            return NoContent();
        }

        [HttpDelete("{propId}/{orderId}")]
        public IActionResult DeleteOrderDetail(int propId, int orderId)
        {
            var p = repository.GetOrderDetailById(propId, orderId);
            if (p == null)
            {
                return NotFound();
            }
            repository.DeleteOrderDetail(p);
            return NoContent();
        }

        [HttpPut("{propId}/{orderId}")]
        public IActionResult UpdateOrderDetail(int propId, int orderId, OrderDetail orderDetail)
        {
            var temp = repository.GetOrderDetailById(propId, orderId);
            if (temp == null)
            {
                return NotFound();
            }
            repository.UpdateOrderDetail(orderDetail);
            return NoContent();
        }
    }
}
