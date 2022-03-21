using System.ComponentModel.DataAnnotations;
using WebShop.Models.Enteties;

namespace WebShop.Models.ViewModels
{
    public class CreateOrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int TotalPrice { get; set; } //Summan av listan ProductOrders
        [Display(Name = "Customer")]
        public int AppUserId { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
    }
}
