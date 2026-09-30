using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NnmLesson12EFCore.Data;
using NnmLesson12EFCore.Helpers;
using NnmLesson12EFCore.Models;

namespace NnmLesson12EFCore.Controllers;

public class NnmProductsController : Controller
{
    private readonly NnmAppDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public NnmProductsController(NnmAppDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.NnmProducts.Include(x => x.NnmCategory).AsNoTracking().ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var nnmItem = await _context.NnmProducts.Include(x => x.NnmCategory).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (nnmItem == null) return NotFound();
        return View(nnmItem);
    }

    public IActionResult Create()
    {
        SetSelectList();
        return View(new NnmProduct());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("NnmName,NnmPrice,NnmSalePrice,NnmStatus,NnmDescriptions,NnmCategoryId")] NnmProduct nnmItem, IFormFile? NnmUpload)
    {
        await ValidateAsync(nnmItem, 0);
        ValidateImage(NnmUpload, true);
        if (ModelState.IsValid)
        {
            try
            {
                nnmItem.NnmCreatedDate = DateTime.Now;
                nnmItem.NnmImage = await NnmImageUpload.SaveAsync(NnmUpload!, _environment.WebRootPath, "Product");
                _context.Add(nnmItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Không thể lưu dữ liệu. Kiểm tra dữ liệu trùng hoặc dữ liệu liên quan đã thay đổi.");
            }
        }
        SetSelectList(nnmItem.NnmCategoryId);
        return View(nnmItem);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var nnmItem = await _context.NnmProducts.FindAsync(id);
        if (nnmItem == null) return NotFound();
        SetSelectList(nnmItem.NnmCategoryId);
        return View(nnmItem);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,NnmName,NnmPrice,NnmSalePrice,NnmStatus,NnmDescriptions,NnmCategoryId")] NnmProduct nnmItem, IFormFile? NnmUpload)
    {
        if (id != nnmItem.Id) return NotFound();
        var current = await _context.NnmProducts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (current == null) return NotFound();
        await ValidateAsync(nnmItem, id);
        nnmItem.NnmImage = current.NnmImage;
        ValidateImage(NnmUpload, false);
        if (ModelState.IsValid)
        {
            try
            {
                nnmItem.NnmCreatedDate = DateTime.Now;
                if (NnmUpload != null && NnmUpload.Length > 0)
                    nnmItem.NnmImage = await NnmImageUpload.SaveAsync(NnmUpload, _environment.WebRootPath, "Product");
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
        SetSelectList(nnmItem.NnmCategoryId);
        return View(nnmItem);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var nnmItem = await _context.NnmProducts.Include(x => x.NnmCategory).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (nnmItem == null) return NotFound();
        return View(nnmItem);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var nnmItem = await _context.NnmProducts.Include(x => x.NnmCategory).FirstOrDefaultAsync(x => x.Id == id);
        if (nnmItem == null) return NotFound();
        try
        {
            _context.NnmProducts.Remove(nnmItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Không thể xóa vì dữ liệu đang được sử dụng.");
            return View("Delete", nnmItem);
        }
    }

    private async Task ValidateAsync(NnmProduct nnmItem, int id)
    {
        if (nnmItem.NnmSalePrice > nnmItem.NnmPrice)
            ModelState.AddModelError(nameof(nnmItem.NnmSalePrice), "Giá khuyến mại không được lớn hơn giá bán");
        if (!await _context.NnmCategories.AnyAsync(c => c.Id == nnmItem.NnmCategoryId))
            ModelState.AddModelError(nameof(nnmItem.NnmCategoryId), "Danh mục không tồn tại");
    }

    private void SetSelectList(int? selected = null)
    {
        ViewData["NnmCategoryId"] = new SelectList(_context.NnmCategories.OrderBy(x => x.NnmName), "Id", "NnmName", selected);
    }

    private void ValidateImage(IFormFile? file, bool required)
    {
        var error = NnmImageUpload.Validate(file, required);
        if (error != null)
            ModelState.AddModelError("NnmUpload", error);
    }
}
