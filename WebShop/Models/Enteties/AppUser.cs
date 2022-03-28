using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.Enteties
{
    public class AppUser  : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        //public string PW { get; internal set; }
    }
}
