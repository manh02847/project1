using Microsoft.AspNetCore.Mvc;

namespace NnmLesson13Layout.Controllers;

public class NnmHomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }
}
