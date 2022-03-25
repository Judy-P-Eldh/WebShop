using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShop.Data;
using WebShop.Models.Enteties;
using WebShop.Models.ViewModels;
using WebShop.Repositories;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        //private readonly ProductRepository productRepository;
        //private readonly ProductOrderRepository productOrderRepository;
        //private readonly OrderRepository orderRepository;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            //this.productRepository = productRepository;
            //this.productOrderRepository = productOrderRepository;
            //this.orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index()
        {
            //if (User.IsInRole("Staff"))
            //{

            //}
            var products = await unitOfWork.ProductRepository.GetAllProductsAsync();
            var viewModel = products.Select(p => new ProductViewModel 
            {
              Id = p.Id,
              Title = p.Title,
              Description = p.Description,
              Price = p.Price,
              Image = p.Image,
              Category = p.Category,
              Size = p.Size

           }).ToList();

            return View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            if(User.IsInRole("Staff"))
            {
                return View();
            }
            if(User.IsInRole("Customer"))
            {
                RedirectToAction(nameof(Index));
            }

            return View();
        }

    }
}
