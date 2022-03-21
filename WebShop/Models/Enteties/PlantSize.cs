namespace WebShop.Models.Enteties
{
    public class PlantSize
    {
        public int Id { get; set; }
       
        public int Size { get; set; }
                               
        
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }      
}