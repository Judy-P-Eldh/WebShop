namespace WebShop.Models.Enteties
{
    public class Product 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int PlantCategoryId { get; set; }
        public string Image { get; set; }
        public PlantCategory Category { get; set; }
        public int PlantSizeId { get; set; }
        public PlantSize Size { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();
    }
}
