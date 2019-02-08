using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product  Product { get; set; }
    }
}
