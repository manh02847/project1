using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NnmLesson12EFCore.Data;
using NnmLesson12EFCore.Helpers;
using NnmLesson12EFCore.Models;

namespace NnmLesson12EFCore.Controllers;

public class NnmCategoriesController : Controller
{
    private readonly NnmAppDbContext _context;

    public NnmCategoriesController(NnmAppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.NnmCategories.AsNoTracking().ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var nnmItem = await _context.NnmCategories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (nnmItem == null) return NotFound();
        return View(nnmItem);
    }

    public IActionResult Create()
    {
        return View(new NnmCategory());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("NnmName,NnmStatus")] NnmCategory nnmItem)
    {
        if (ModelState.IsValid)
        {
            try
            {
                nnmItem.NnmCreatedDate = DateTime.Now;
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
        var nnmItem = await _context.NnmCategories.FindAsync(id);
        if (nnmItem == null) return NotFound();
        return View(nnmItem);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,NnmName,NnmStatus")] NnmCategory nnmItem)
    {
        if (id != nnmItem.Id) return NotFound();
        var current = await _context.NnmCategories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (current == null) return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                nnmItem.NnmCreatedDate = DateTime.Now;
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
        var nnmItem = await _context.NnmCategories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (nnmItem == null) return NotFound();
        return View(nnmItem);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var nnmItem = await _context.NnmCategories.FirstOrDefaultAsync(x => x.Id == id);
        if (nnmItem == null) return NotFound();
        if (await _context.NnmProducts.AnyAsync(p => p.NnmCategoryId == id))
        {
            ModelState.AddModelError("", "Danh mục đang có sản phẩm. Hãy chuyển hoặc xóa sản phẩm trước.");
            return View("Delete", nnmItem);
        }

        try
        {
            _context.NnmCategories.Remove(nnmItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Không thể xóa vì dữ liệu đang được sử dụng.");
            return View("Delete", nnmItem);
        }
    }

}
