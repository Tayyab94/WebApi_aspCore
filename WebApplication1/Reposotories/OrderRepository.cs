using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Contract;
using WebApplication1.Models;

namespace WebApplication1.Reposotories
{
    public class OrderRepository : IOrderRepository
    {
        private DemoContaxt _context;

        private IMemoryCache cache;

        public OrderRepository(DemoContaxt db, IMemoryCache memory)
        {
            _context = db;
            cache = memory;
        }

        public void Add(Order item)
        {
            _context.Orders.Add(item);

            cache.Set(item.ID, item, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow=TimeSpan.FromMinutes(40)
            });

            _context.SaveChanges();
        }

        public Order Find(int key)
        {
            Order order = null;

            if(cache.TryGetValue(key,out order))
            {
                return order;
            }
            else
            {
                return _context.Orders.Include(x => x.Customer).Include(x => x.SalePerson).SingleOrDefault(s => s.ID == key);
            }
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }

        public Order Remove(int key)
        {
            var item = _context.Orders.SingleOrDefault(s => s.ID == key);

            _context.Orders.Remove(item);
            _context.SaveChanges();

            return item;
        }

        public void Update(Order item)
        {
            _context.Orders.Update(item);

            _context.SaveChanges();
        }
    }
}
