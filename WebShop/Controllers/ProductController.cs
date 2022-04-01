using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plant.Core.DTOs;
using WebShop.Clients;
using WebShop.Data;
using WebShop.Models.Enteties;
using WebShop.Models.ViewModels;
using WebShop.Repositories;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly WebShopClient webShopClient;

        public ProductController(IUnitOfWork unitOfWork, WebShopClient webShopClient)
        {
            this.unitOfWork = unitOfWork;
            this.webShopClient = webShopClient;
        }

        public async Task<IActionResult> Index()
        {
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

        public async Task<IActionResult> EventsView()
        {
            var events = await webShopClient.GetEventStreamsAsync();
            var view = events.Select(e => new EventDto
            {
                Title = e.Title,
                Description = e.Description,
                Date = e.Date,
                Address = e.Address,
                Offers =  e.Offers

            }).ToList();
            return View(view);

        }

        //[Authorize]
        //public async Task<IActionResult> Profile()
        //{
        //    if(User.IsInRole("Staff"))
        //    {
        //        return View();
        //    }
        //    if(User.IsInRole("Customer"))
        //    {
        //        RedirectToAction(nameof(Index));
        //    }

        //    return View();
        //}

    }
}
