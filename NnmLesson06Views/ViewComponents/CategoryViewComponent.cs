using Microsoft.AspNetCore.Mvc;
using NnmLesson06Views.Models;

namespace NnmLesson06Views.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int n = 0)
        {
            var categories = new List<Category>
            {
                new Category { CategoryId = 1, CategoryName = "Điện tử" },
                new Category { CategoryId = 2, CategoryName = "Điện lạnh" },
                new Category { CategoryId = 3, CategoryName = "Đồ gia dụng" },
                new Category { CategoryId = 4, CategoryName = "Tiện ích" }
            };

            return View(categories.Where(x => x.CategoryId > n).ToList());
        }
    }
}
