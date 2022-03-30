using WebShop.Data;

namespace WebShop.Repositories
{
    public class CustomerRepository
    {
        private readonly ApplicationDbContext db;

        public CustomerRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}
