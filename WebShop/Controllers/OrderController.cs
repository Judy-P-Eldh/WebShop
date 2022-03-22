using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Data;
using WebShop.Models.Enteties;
using WebShop.Models.ViewModels;
using WebShop.Repositories;

namespace WebShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderRepository orderRepository;
        private readonly ProductRepository productRepository;
        private readonly ProductOrderRepository productOrderRepository;

        public OrderController(OrderRepository orderRepository, ProductRepository productRepository, ProductOrderRepository productOrderRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.productOrderRepository = productOrderRepository;
        }
        public async Task<IActionResult> Index()
        {
            var oredersFromRepo = await orderRepository.GetAllOrdersAsync();
            var orders = oredersFromRepo.Select(o => new OrderViewModel
            {
                Id = o.Id,
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
            
            var product = await productRepository.GetProductByIdAsync(id);

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

            orderRepository.AddOrder(order);
            productOrderRepository.AddProductOrder(productOrder);

            orderRepository.SaveChanges();

            var ordersFromRepo = await orderRepository.GetAllOrdersAsync();
            var viewModel = ordersFromRepo.Select(o => new OrderViewModel()
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = totalPrice,
                ProductOrders = o.ProductOrders
            });//.ToListAsync();

            return View(viewModel);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                throw new Exception("Nothing to delete.");
            }

            var order = await orderRepository.GetOrderById((int)id);

            if (order is null) return NotFound();

            orderRepository.RemoveOrder(order);
            orderRepository.SaveChanges();

            return RedirectToAction(nameof(Index)); 
        }
    }
}
