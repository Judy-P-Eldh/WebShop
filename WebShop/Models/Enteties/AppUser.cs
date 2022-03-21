using Microsoft.AspNetCore.Identity;

namespace WebShop.Models.Enteties
{
    public class AppUser  : IdentityUser
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
