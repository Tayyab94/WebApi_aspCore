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
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerRepository CustomerItem { get; set; }
       private DemoContaxt _context;

        //private List<values1> l;

        //public CustomerController()
        //{
        //    l = new List<values1>();

        //    l.Add(new values1(1, "Tayyab"));
        //    l.Add(new values1(2, "Bhattu"));
        //    l.Add(new values1(3, "Ali"));
        //    l.Add(new values1(4, "Tayyab Ashref"));
        //    l.Add(new values1(5, "Bhatti Shb"));
        //    l.Add(new values1(6, "Ali Ahmad"));
        //}


        //[HttpGet]
        //public IEnumerable<values> Get()
        //{
        //   return l;
        //}

        //[HttpGet("{id}")]
        //public values Get(int id)
        //{
        //    return listVal.Find(a => a.ID == id);
        //}


        public CustomerController(ICustomerRepository repository,DemoContaxt d)
        {
            CustomerItem = repository;
            _context = d;
        }


        [HttpGet]
        [ResponseCache(Duration =60,Location =ResponseCacheLocation.Client)]

        public IEnumerable<Customer> GetAll()
        {
            return CustomerItem.GetAll();       
            //return _context.Customers.ToList();
        }



        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult Get(int id)
        {
            var item = CustomerItem.Find(id);
            if (item == null)
                return NotFound();

            return new ObjectResult(item);
        }


        [HttpPost]

        public IActionResult Post([FromBody]Customer value)
        {
            if (value == null)
                return BadRequest();
            TryValidateModel(value);
            if(this.ModelState.IsValid)
            {

                CustomerItem.Add(value);
            }
            else
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetCustomer", new { contrller = "Customer", id = value.ID }, value);
        }


        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody]Customer value)
        {
            var customer = CustomerItem.Find(id);

            CustomerItem.Update(value);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CustomerItem.Remove(id);
        }
    }

    public class values1
    {

        public values1(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public int ID { get; set; }

        public string Name { get; set; }
    }
}