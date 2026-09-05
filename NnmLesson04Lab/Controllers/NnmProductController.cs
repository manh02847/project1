using Microsoft.AspNetCore.Mvc;
using NnmLesson04Lab.Models;

namespace NnmLesson04Lab.Controllers
{
    [Route("san-pham")]
    public class NnmProductController : Controller
    {
        private readonly List<NnmCategory> nnmCategories = new()
        {
            new NnmCategory { Id = 1, Name = "Quần áo" },
            new NnmCategory { Id = 2, Name = "Túi xách" },
            new NnmCategory { Id = 3, Name = "Đồng hồ" },
            new NnmCategory { Id = 4, Name = "Tivi" },
            new NnmCategory { Id = 5, Name = "Tủ lạnh" }
        };

        private readonly List<NnmProduct> nnmProducts = new()
        {
            new NnmProduct
            {
                Id = 1,
                Name = "Áo thun nam basic",
                Image = "/images/product-shirt.svg",
                Price = 250000m,
                SalePrice = 199000m,
                CategoryId = 1,
                Description = "Áo thun nam chất liệu cotton, kiểu dáng đơn giản.",
                Status = true,
                CreatedAt = new DateTime(2026, 8, 20)
            },
            new NnmProduct
            {
                Id = 2,
                Name = "Áo khoác nữ",
                Image = "/images/product-jacket.svg",
                Price = 450000m,
                SalePrice = 399000m,
                CategoryId = 1,
                Description = "Áo khoác nữ nhẹ, phù hợp sử dụng hằng ngày.",
                Status = true,
                CreatedAt = new DateTime(2026, 8, 21)
            },
            new NnmProduct
            {
                Id = 3,
                Name = "Túi xách thời trang",
                Image = "/images/product-bag.svg",
                Price = 650000m,
                SalePrice = 550000m,
                CategoryId = 2,
                Description = "Túi xách nhỏ gọn, thiết kế trẻ trung.",
                Status = true,
                CreatedAt = new DateTime(2026, 8, 22)
            },
            new NnmProduct
            {
                Id = 4,
                Name = "Đồng hồ nam",
                Image = "/images/product-watch.svg",
                Price = 1200000m,
                SalePrice = 990000m,
                CategoryId = 3,
                Description = "Đồng hồ nam dây da, mặt kính chống xước.",
                Status = true,
                CreatedAt = new DateTime(2026, 8, 23)
            },
            new NnmProduct
            {
                Id = 5,
                Name = "Smart TV 43 inch",
                Image = "/images/product-tv.svg",
                Price = 8500000m,
                SalePrice = 7900000m,
                CategoryId = 4,
                Description = "Smart TV độ phân giải 4K, hỗ trợ kết nối Internet.",
                Status = true,
                CreatedAt = new DateTime(2026, 8, 24)
            },
            new NnmProduct
            {
                Id = 6,
                Name = "Tủ lạnh 236 lít",
                Image = "/images/product-fridge.svg",
                Price = 7200000m,
                SalePrice = 6790000m,
                CategoryId = 5,
                Description = "Tủ lạnh hai cánh, dung tích 236 lít.",
                Status = true,
                CreatedAt = new DateTime(2026, 8, 25)
            }
        };

        [HttpGet("", Name = "nnmproduct")]
        public IActionResult NnmIndex(int? categoryId)
        {
            ViewBag.NnmCategories = nnmCategories;
            ViewBag.NnmProducts = categoryId == null
                ? nnmProducts
                : nnmProducts.Where(x => x.CategoryId == categoryId).ToList();
            ViewBag.SelectedCategoryId = categoryId;
            return View();
        }

        [HttpGet("chi-tiet/{id:int}", Name = "nnmproductdetail")]
        public IActionResult NnmDetails(int id)
        {
            NnmProduct? product = nnmProducts.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();

            ViewBag.NnmProduct = product;
            ViewBag.NnmCategory = nnmCategories.FirstOrDefault(x => x.Id == product.CategoryId);
            return View();
        }
    }
}
