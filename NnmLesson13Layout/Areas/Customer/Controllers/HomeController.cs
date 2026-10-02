using Microsoft.AspNetCore.Mvc;

namespace NnmLesson13Layout.Areas.Customer.Controllers;

[Area("Customer")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
