using WebShop.Models.Enteties;

namespace WebShop.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Image { get; set; } 
        public PlantCategory Category { get; set; }
        public PlantSize Size { get; set; }
    }
}
