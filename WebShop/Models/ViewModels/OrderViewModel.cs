using System.ComponentModel.DataAnnotations;
using WebShop.Models.Enteties;

namespace WebShop.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int TotalPrice { get; set; }
        [Display(Name = "Customer")]
        public string AppUserId { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
    }
}
