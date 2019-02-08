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
    public class OrderItemController : Controller
    {
        private IOrderItemRepository itemRepository;


        public OrderItemController(IOrderItemRepository order)
        {
            itemRepository = order;
        }


        [HttpGet]
        [ResponseCache(Duration = 40, Location = ResponseCacheLocation.Client)]
        public IEnumerable<OrderItem> GetAll()
        {
            return itemRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetOrderItem")]
        public IActionResult Get(int id)
        {
            var item = itemRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderItem val)
        {
            if (val == null)
            {
                return BadRequest();
            }

            TryValidateModel(val);

            if (this.ModelState.IsValid)
            {
                itemRepository.Add(val);
            } else
            {
                return BadRequest();
            }

            return CreatedAtRoute("GetOrderItem", new { controller = "OrderItem", id = val.Id }, val);
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id,[FromBody]OrderItem val)
        {
            var orderItem = itemRepository.Find(id);

            itemRepository.Update(val);
            return new NoContentResult();
        }



        [HttpDelete("{id}")]

        public void Delete(int id)
        {
            itemRepository.Remove(id);
        }


    }

}