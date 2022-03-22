using WebShop.Data;
using WebShop.Models.Enteties;

namespace WebShop.Repositories
{
    public class ProductOrderRepository : IProductOrderRepository
    {
        private readonly ApplicationDbContext db;

        public ProductOrderRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddProductOrder(ProductOrder productOrder)
        {
            db.Add(productOrder);
        }

    }
}
