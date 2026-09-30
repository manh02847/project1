using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NnmLesson12EFCore.Data;
using NnmLesson12EFCore.Helpers;
using NnmLesson12EFCore.Models;

namespace NnmLesson12EFCore.Controllers;

public class NnmBannersController : Controller
{
    private readonly NnmAppDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public NnmBannersController(NnmAppDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.NnmBanners.AsNoTracking().ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var nnmItem = await _context.NnmBanners.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (nnmItem == null) return NotFound();
        return View(nnmItem);
    }

    public IActionResult Create()
    {
        return View(new NnmBanner());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("NnmName,NnmDescription,NnmStatus")] NnmBanner nnmItem, IFormFile? NnmUpload)
    {
        ValidateImage(NnmUpload, true);
        if (ModelState.IsValid)
        {
            try
            {
                nnmItem.NnmCreatedDate = DateTime.Now;
                nnmItem.NnmImage = await NnmImageUpload.SaveAsync(NnmUpload!, _environment.WebRootPath, "Banner");
                _context.Add(nnmItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Không thể lưu dữ liệu. Kiểm tra dữ liệu trùng hoặc dữ liệu liên quan đã thay đổi.");
            }
        }
        return View(nnmItem);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var nnmItem = await _context.NnmBanners.FindAsync(id);
        if (nnmItem == null) return NotFound();
        return View(nnmItem);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,NnmName,NnmDescription,NnmStatus")] NnmBanner nnmItem, IFormFile? NnmUpload)
    {
        if (id != nnmItem.Id) return NotFound();
        var current = await _context.NnmBanners.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (current == null) return NotFound();
        nnmItem.NnmImage = current.NnmImage;
        ValidateImage(NnmUpload, false);
        if (ModelState.IsValid)
        {
            try
            {
                nnmItem.NnmCreatedDate = DateTime.Now;
                if (NnmUpload != null && NnmUpload.Length > 0)
                    nnmItem.NnmImage = await NnmImageUpload.SaveAsync(NnmUpload, _environment.WebRootPath, "Banner");
                _context.Update(nnmItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Không thể cập nhật. Kiểm tra dữ liệu trùng hoặc dữ liệu liên quan đã thay đổi.");
            }
        }
        return View(nnmItem);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var nnmItem = await _context.NnmBanners.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (nnmItem == null) return NotFound();
        return View(nnmItem);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var nnmItem = await _context.NnmBanners.FirstOrDefaultAsync(x => x.Id == id);
        if (nnmItem == null) return NotFound();
        try
        {
            _context.NnmBanners.Remove(nnmItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Không thể xóa vì dữ liệu đang được sử dụng.");
            return View("Delete", nnmItem);
        }
    }

    private void ValidateImage(IFormFile? file, bool required)
    {
        var error = NnmImageUpload.Validate(file, required);
        if (error != null)
            ModelState.AddModelError("NnmUpload", error);
    }
}
