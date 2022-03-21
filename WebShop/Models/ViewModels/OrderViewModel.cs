using System.ComponentModel.DataAnnotations;
using WebShop.Models.Enteties;

namespace WebShop.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int TotalPrice { get; set; }
        [Display(Name = "Customer")]
        public int AppUserId { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
    }
}
