using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        public int ID { get; set; }
        public DateTime Date { get; set; }

        public decimal TotalDue { get; set; }

        public string Status { get; set; }

        public int CustomerId { get; set; }

        public int SalePersonId { get; set; }


        public virtual Customer   Customer { get; set; }

        public virtual SalePerson SalePerson { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
