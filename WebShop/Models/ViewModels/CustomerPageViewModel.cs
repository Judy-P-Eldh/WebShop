using System.ComponentModel.DataAnnotations;
using WebShop.Models.Enteties;

namespace WebShop.Models.ViewModels
{
    public class CustomerPageViewModel
    {
        [Display(Name = "Customer")]
        public string AppUserId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Register Date")]
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        //Messages, favourites personal info, offers
    }
}
