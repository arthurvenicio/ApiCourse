using ApiCourse.Models;
using ApiCourse.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCourse.Controllers
{
    [ApiController]
    [Route("/api/v1/[Controller]")]
    public class OrderController : ControllerBase
    {
        public OrderController()
        {
        }

        [HttpGet("list")]
        public ActionResult<List<Order>> GetAll()
        {
            return OrderService.GetAll();
        }

        [HttpGet("{uuid}")]
        public ActionResult<Order> Get(string uuid)
        {
            var order = OrderService.GetOrder(uuid);

            if (order == null)
                return NotFound();

            return order;

        }

        [HttpPost("create")]
        public IActionResult Create(Order order)
        {
            try
            {
                OrderService.Add(order);
                return CreatedAtAction(nameof(Create), new {uuid = order.Uuid}, order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{uuid}")]
        public IActionResult Update(string uuid, Order order)
        {

            if (uuid != order.Uuid)
               return BadRequest();

            var existingOrder = OrderService.GetOrder(uuid);
            if (existingOrder is null)
                return NotFound();

            OrderService.Update(order);
            return Ok(order);
        }

        [HttpDelete("delete/{uuid}")]
        public IActionResult Delete(string uuid)
        {
            try
            {
                OrderService.Remove(uuid);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
