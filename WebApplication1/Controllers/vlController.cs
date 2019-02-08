using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]

    public class vlController : Controller
    {

        private List<values> listVal;

        public vlController()
        {
            listVal = new List<values>();

            listVal.Add(new values(1, "Tayyab"));
            listVal.Add(new values(2, "Bhattu"));
            listVal.Add(new values(3, "Ali"));
            listVal.Add(new values(4, "Tayyab Ashref"));
            listVal.Add(new values(5, "Bhatti Shb"));
            listVal.Add(new values(6, "Ali Ahmad"));
        }


        [HttpGet]
        public IEnumerable<values> Get()
        {
            return listVal;
        }

        [HttpGet("{id}")]
        public values Get(int id)
        {
            return listVal.Find(a => a.ID == id);
        }
    }

    public class values
    {

        public values(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public int ID { get; set; }

        public string Name { get; set; }
    }
}