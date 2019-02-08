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
    public class OrderItemRepository : IOrderItemRepository
    {
        private DemoContaxt _context;


        private IMemoryCache cache;
        public OrderItemRepository(DemoContaxt repository,IMemoryCache memory)
        {
            _context = repository;
            cache = memory;
        }

        
        public IEnumerable<OrderItem> GetAll() => _context.OrderItems;
        public void Add(OrderItem item)
        {
            _context.OrderItems.Add(item);

            cache.Set(item.Id, item, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
            });

            _context.SaveChanges();

        }

        public OrderItem Find(int key)
        {
        

            OrderItem orderItemCache = null;

            if (cache.TryGetValue(key, out orderItemCache)){

                return orderItemCache;

            }else
            {

                return  _context.OrderItems.Include(x => x.Order).Include(x => x.Product).SingleOrDefault(x => x.Id == key);            
            }
        }


        public OrderItem Remove(int key)
        {
            var item = _context.OrderItems.SingleOrDefault(s => s.Id == key);

            _context.OrderItems.Remove(item);

            _context.SaveChanges();

            return item;
        }

        public void Update(OrderItem item)
        {
            _context.OrderItems.Update(item);
            _context.SaveChanges();
        }
    }
}
