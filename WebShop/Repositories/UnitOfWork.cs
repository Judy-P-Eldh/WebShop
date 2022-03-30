using WebShop.Data;

namespace WebShop.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;

        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IProductOrderRepository ProductOrderRepository { get; }
        public ICustomerRepository CustomerRepository { get; }

        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;
            ProductRepository = new ProductRepository(db);
            OrderRepository = new OrderRepository(db);
            ProductOrderRepository = new ProductOrderRepository(db);
            CustomerRepository = new CustomerRepository(db);
        }
        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
