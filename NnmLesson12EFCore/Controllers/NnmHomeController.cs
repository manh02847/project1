using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NnmLesson12EFCore.Data;
using NnmLesson12EFCore.Models;

namespace NnmLesson12EFCore.Controllers;

public class NnmHomeController : Controller
{
    private readonly NnmAppDbContext _context;

    public NnmHomeController(NnmAppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> NnmIndex()
    {
        return View(await _context.NnmBanners.Where(b => b.NnmStatus == 1)
            .OrderBy(b => b.Id).AsNoTracking().ToListAsync());
    }

    public async Task<IActionResult> Product()
    {
        return View(await _context.NnmProducts.Include(p => p.NnmCategory)
            .Where(p => p.NnmStatus == 1 && p.NnmCategory.NnmStatus == 1)
            .OrderBy(p => p.Id).AsNoTracking().ToListAsync());
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
