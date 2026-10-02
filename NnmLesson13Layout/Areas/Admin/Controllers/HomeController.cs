using Microsoft.AspNetCore.Mvc;

namespace NnmLesson13Layout.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
