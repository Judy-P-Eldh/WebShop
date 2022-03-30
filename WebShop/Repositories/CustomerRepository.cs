using Microsoft.AspNetCore.Identity;
using System.Linq;
using WebShop.Data;
using WebShop.Models.Enteties;

namespace WebShop.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext db;

        public CustomerRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<AppUser> GetUserByIdAsync(string id)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == id);
            var userOrders = user.Orders.ToList();

            return user;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
