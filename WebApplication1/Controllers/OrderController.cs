using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contract;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;

        public OrderController(IOrderRepository order)
        {
            orderRepository = order;
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public IEnumerable<Order> GetAll()
        {
            return orderRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult GetAll(int id)
        {
            var item = orderRepository.Find(id);

            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(item);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody]Order val)
        {
            if (val == null)
                return BadRequest();

            TryValidateModel(val);
            if (this.ModelState.IsValid)
            {
                orderRepository.Add(val);

            }
            else
            {
                return BadRequest();
            }

            return CreatedAtRoute("GetOrder", new { controller = "Order", id = val.ID }, val);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody]Order val)
        {
            var item = orderRepository.Find(id);
            orderRepository.Update(val);
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderRepository.Remove(id);
        }
    }
}