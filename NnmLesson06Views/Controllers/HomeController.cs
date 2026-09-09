using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NnmLesson06Views.Models;

namespace NnmLesson06Views.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(GetProducts());
        }

        public PartialViewResult GetProductHot()
        {
            return PartialView("_ProductHotPartialView", GetProducts());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult About()
        {
            return View();
        }

        // lập trình trên view với Razor code
        public IActionResult RazorCode() 
        {
            return View();
        }

        private static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Sản phẩm 1", Price = 500000, Image = "icon1.png" },
                new Product { Id = 2, Name = "Sản phẩm 2", Price = 700000, Image = "icon2.png" },
                new Product { Id = 3, Name = "Sản phẩm 3", Price = 550000, Image = "icon3.png" }
            };
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
