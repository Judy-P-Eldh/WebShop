using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Data;
using WebShop.Models.Enteties;
using WebShop.Models.ViewModels;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
        
        public ProductController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
           var products = db.Products.Select(p => new ProductViewModel 
           {
              Id = p.Id,
              Title = p.Title,
              Description = p.Description,
              Price = p.Price,
              Image = p.Image,
              Category = p.Category,
              Size = p.Size

           }).ToList();

            return View(products);
        }
    }
}
