using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Data;
using WebShop.Models.Enteties;

namespace WebShop.Repositories
{
    public class OrderRepository
    {
        private readonly ApplicationDbContext db;

        public OrderRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await db.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await db.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async void AddOrder(Order order)
        {
            db.Orders.Add(order);
            
        }
        public void RemoveOrder(Order order)
        {
            db.Orders.Remove(order);        
            
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        
    }
}
