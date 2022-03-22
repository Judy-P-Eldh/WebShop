using WebShop.Models.Enteties;

namespace WebShop.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> FilterByCategoryAsync(PlantCategory category);
        Task<IEnumerable<Product>> FilterBySize(PlantSize size);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        void SaveChanges();
    }
}