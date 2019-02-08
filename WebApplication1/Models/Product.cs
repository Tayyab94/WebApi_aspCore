using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Product
    {

        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }
          public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Size { get; set; }
        public string Variety { get; set; }
        public decimal? Price { get; set; }
        public string Status { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
