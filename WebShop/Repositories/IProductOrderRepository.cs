using WebShop.Models.Enteties;

namespace WebShop.Repositories
{
    public interface IProductOrderRepository
    {
        void AddProductOrder(ProductOrder productOrder);
    }
}