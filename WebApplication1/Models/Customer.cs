using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Customer
    {

        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; }



    }
}
