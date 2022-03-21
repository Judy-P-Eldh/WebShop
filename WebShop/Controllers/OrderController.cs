using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Data;
using WebShop.Models.Enteties;
using WebShop.Models.ViewModels;

namespace WebShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext db;

        public OrderController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var orders = db.Orders.Select(o => new OrderViewModel
            {
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                //AppUserId = o.AppUserId,
                ProductOrders = o.ProductOrders

            }).ToList();

            return View(orders);
        }

        //public async Task<IActionResult> Create(int id, DateTime orderDate, int totalPrice, int appUserId, List<ProductOrder> productOrders)
        //{
        //    var viewModel = new OrderViewModel();
        //    db.Add(new Order()
        //    {
        //        OrderDate = orderDate,
        //        TotalPrice = totalPrice,
        //        AppUserId = appUserId,
        //        ProductOrders = productOrders
        //    });

        //    return View(viewModel);
        //}

        public async Task<IActionResult> Buy(int id, int amount)
        {
            if (id == null)
            {
                return View("Error");
            }
            
            var product = db.Products.FirstOrDefault(p => p.Id == id);

            amount = 2;
            var price = product.Price;
            var totalPrice = price * amount;

            var order = new Order()
            {
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice
            };
            var productOrder = (new ProductOrder()
            {
                Order = order,
                Amount = amount,
                ProductId = id
            });

            db.Add(order);
            db.Add(productOrder);

            await db.SaveChangesAsync();

            var orders =  await db.Orders.ToListAsync();
            var viewModel = orders.Select(o => new OrderViewModel
            {   
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = totalPrice,
                ProductOrders = o.ProductOrders
            }).ToList();

            return View(viewModel);
        }
        //[HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                throw new Exception("Nothing to delete.");
            }

            var order = db.Orders.FirstOrDefault(p => p.Id == id);
            db.Orders.Remove(order);  //Tas inte bort?

            return View(nameof(Index)); 
        }
    }
}
