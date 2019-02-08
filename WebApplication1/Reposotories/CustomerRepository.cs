using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Contract;
using WebApplication1.Models;
using Microsoft.Extensions.Caching.Memory;

namespace WebApplication1.Reposotories
{
    public class CustomerRepository : ICustomerRepository
    {
        private DemoContaxt _context;

        private IMemoryCache Cache;

        public CustomerRepository(DemoContaxt db,IMemoryCache memory)
        {
            _context = db;
            Cache = memory;
        }


        public IEnumerable<Customer> GetAll()
            => _context.Customers;
        

        public void Add(Customer item)
        {
            _context.Customers.Add(item);
            Cache.Set(item.ID, item, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
            });
            _context.SaveChanges();
        }

        public Customer Find(int key) /*=> _context.Customers.Include(c => c.Orders).SingleOrDefault(s => s.ID == key);*/
        {
            Customer cachedCustomer = null;

            if(Cache.TryGetValue(key,out cachedCustomer))
            {
                return cachedCustomer;
            }
            else
            {
                var item = _context.Customers.Include(x => x.Orders).SingleOrDefault(x => x.ID == key);

                return item;
            }
        }

        public Customer Remove(int key)
        {
            var cus = _context.Customers.Single(s => s.ID == key);

            _context.Customers.Remove(cus);

            _context.SaveChanges();

            return cus;
        }

        public void Update(Customer item)
        {
            _context.Customers.Update(item);

            _context.SaveChanges();
        }
    }
}
