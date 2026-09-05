using Microsoft.AspNetCore.Mvc;
using NnmLesson03.Models;

namespace NnmLesson03.Controllers
{
    [Route("/danh-sach-san-pham")]
    public class NnmProductController : Controller
    {
        // Mock data
        private readonly List<NnmProduct> _products = new()
        {
            new NnmProduct
            {
                NnmProductId = "NNM-MB-001",
                NnmProductName = "iPhone 15 Pro Max 256GB",
                NnmYearRelease = 2023,
                NnmPrice = 29990000m
            },
            new NnmProduct
            {
                NnmProductId = "NNM-MB-002",
                NnmProductName = "Samsung Galaxy S24 Ultra 512GB",
                NnmYearRelease = 2024,
                NnmPrice = 31490000m
            },
            new NnmProduct
            {
                NnmProductId = "NNM-MB-003",
                NnmProductName = "Xiaomi 14 Ultra 5G",
                NnmYearRelease = 2024,
                NnmPrice = 27990000m
            },
            new NnmProduct
            {
                NnmProductId = "NNM-MB-004",
                NnmProductName = "Google Pixel 8 Pro 128GB",
                NnmYearRelease = 2023,
                NnmPrice = 21500000m
            },
            new NnmProduct
            {
                NnmProductId = "NNM-MB-005",
                NnmProductName = "OPPO Find N3 Flip 256GB",
                NnmYearRelease = 2023,
                NnmPrice = 19990000m
            },
            new NnmProduct
            {
                NnmProductId = "NNM-MB-006",
                NnmProductName = "Samsung Galaxy Z Fold5 512GB",
                NnmYearRelease = 2023,
                NnmPrice = 34990000m
            },
            new NnmProduct
            {
                NnmProductId = "NNM-MB-007",
                NnmProductName = "iPad Pro M4 11-inch Wi-Fi 256GB",
                NnmYearRelease = 2024,
                NnmPrice = 28990000m
            },
            new NnmProduct
            {
                NnmProductId = "NNM-MB-008",
                NnmProductName = "Samsung Galaxy Tab S9 Ultra",
                NnmYearRelease = 2023,
                NnmPrice = 25490000m
            },
            new NnmProduct
            {
                NnmProductId = "NNM-MB-009",
                NnmProductName = "ASUS ROG Phone 8 Pro 512GB",
                NnmYearRelease = 2024,
                NnmPrice = 28490000m
            },
            new NnmProduct
            {
                NnmProductId = "NNM-MB-010",
                NnmProductName = "Vivo X100 Pro 5G 256GB",
                NnmYearRelease = 2024,
                NnmPrice = 22990000m
            }
        };
        public IActionResult Index()
        {
            return Json(_products);
        }

        // Collection => view
        [Route("all")]
        public IActionResult NnmGetAllProduct()
        {
            ViewData["products"] = _products;
            return View();
        }
    }
}
