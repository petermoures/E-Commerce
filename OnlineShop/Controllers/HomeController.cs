using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using System.Diagnostics;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnlineShopeEntity onlineShope;
        public HomeController(OnlineShopeEntity _onlineShope)
        {
            onlineShope = _onlineShope;
        }

        public object Session { get; private set; }

        public IActionResult Index()
        {
            List<product> products = onlineShope.Products.ToList();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }   
    
}