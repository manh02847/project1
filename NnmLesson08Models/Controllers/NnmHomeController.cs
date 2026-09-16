using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NnmLesson08Models.Models;

namespace NnmLesson08Models.Controllers
{
    public class NnmHomeController : Controller
    {
        private readonly ILogger<NnmHomeController> _logger;

        public NnmHomeController(ILogger<NnmHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NnmIndex()
        {
            return View();
        }

        public IActionResult NnmPrivacy()
        {
            return View();
        }

        public IActionResult NnmAbout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

