using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Contract
{
    public interface IOrderRepository
    {
        void Add(Order item);

        IEnumerable<Order> GetAll();

        Order Find(int key);

        Order Remove(int key);

        void Update(Order item);
    }
}
