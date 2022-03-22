
namespace WebShop.Repositories
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        IProductOrderRepository ProductOrderRepository { get; }
        IProductRepository ProductRepository { get; }

        Task CompleteAsync();
    }
}