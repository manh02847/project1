using Microsoft.AspNetCore.Mvc;
using NnmLesson02Theory.Models;

namespace NnmLesson02Theory.Controllers
{
    public class NnmProductController : Controller
    {
        public IActionResult NnmIndex()
        {
            // Dữ liệu lưu trong các đối tượng: ViewBag, ViewData, TempData
            ViewBag.name = "Nguyễn Ngọc Mạnh";
            ViewData["productVD"] = "Laptop Dell Vostro";
            TempData["UNI"] = "Trường Đại học Nguyễn Trãi - NTU";

            return View();
        }

        public IActionResult GetProduct()
        {
            // Tạo mock data product
            NnmProduct nnmProduct = new NnmProduct()
            {
                ProductID = "2410900051",
                ProductName = "Nguyễn Ngọc Mạnh",
                YearRelease = 2006,
                Price = 1000
            };

            ViewBag.product = nnmProduct;
            ViewData["product"] = nnmProduct;

            return View("Product");
        }
    }
}
