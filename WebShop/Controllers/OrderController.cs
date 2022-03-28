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
        private readonly IUnitOfWork unitOfWork;

        //private readonly OrderRepository orderRepository;
        //private readonly ProductRepository productRepository;
        //private readonly ProductOrderRepository productOrderRepository;

        public OrderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            //this.orderRepository = orderRepository;
            //this.productRepository = productRepository;
            //this.productOrderRepository = productOrderRepository;
        }
        
        public async Task<IActionResult> Index()
        {
            var oredersFromRepo = await unitOfWork.OrderRepository.GetAllOrdersAsync();
            var orders = oredersFromRepo.Select(o => new OrderViewModel
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                AppUserId = o.AppUserId,
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

        public async Task<IActionResult> Buy(int? id, int amount)
        {
            if (id == null)
            {
                return View("Error");
            }
            
            var product = await unitOfWork.ProductRepository.GetProductByIdAsync((int)id);

            amount = 2;
            var price = product.Price;
            var totalPrice = price * amount;

            var order = new Order()
            {
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                //AppUserId = 
            };
            var productOrder = new ProductOrder()
            {
                Order = order,
                Amount = amount,
                ProductId = (int)id
            };

            unitOfWork.OrderRepository.AddOrder(order);
            unitOfWork.ProductOrderRepository.AddProductOrder(productOrder);

            await unitOfWork.CompleteAsync();

            var ordersFromRepo = await unitOfWork.OrderRepository.GetAllOrdersAsync();
            var viewModel = ordersFromRepo.Select(o => new OrderViewModel()
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = totalPrice,
                ProductOrders = o.ProductOrders
            });

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                throw new Exception("Nothing to delete.");
            }

            var order = await unitOfWork.OrderRepository.GetOrderById((int)id);

            if (order is null) return NotFound();

            unitOfWork.OrderRepository.RemoveOrder(order);
            await unitOfWork.CompleteAsync();

            return RedirectToAction(nameof(Index)); 
        }
    }
}
