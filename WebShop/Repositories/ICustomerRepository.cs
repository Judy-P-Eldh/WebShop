using WebShop.Models.Enteties;

namespace WebShop.Repositories
{
    public interface ICustomerRepository
    {
        Task<AppUser> GetUserByIdAsync(string id);
        void SaveChanges();
    }
}