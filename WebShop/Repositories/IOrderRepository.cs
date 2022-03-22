using WebShop.Models.Enteties;

namespace WebShop.Repositories
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderById(int id);
        void RemoveOrder(Order order);
        void SaveChanges();
    }
}