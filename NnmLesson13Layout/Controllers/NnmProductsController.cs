using Microsoft.AspNetCore.Mvc;

namespace NnmLesson13Layout.Controllers;

public class NnmProductsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Search(string? keyword)
    {
        ViewData["Keyword"] = keyword;
        return View();
    }

    public IActionResult Hots()
    {
        return View();
    }
}
