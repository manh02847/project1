using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NnmLesson12EFCore.Data;
using NnmLesson12EFCore.Helpers;
using NnmLesson12EFCore.Models;

namespace NnmLesson12EFCore.Controllers;

public class NnmSubjectsController : Controller
{
    private readonly NnmStudentDbContext _context;

    public NnmSubjectsController(NnmStudentDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.NnmSubjects.AsNoTracking().ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var nnmItem = await _context.NnmSubjects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (nnmItem == null) return NotFound();
        return View(nnmItem);
    }

    public IActionResult Create()
    {
        return View(new NnmSubject());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("NnmSubjectName")] NnmSubject nnmItem)
    {
        await ValidateAsync(nnmItem, 0);
        if (ModelState.IsValid)
        {
            try
            {
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
        var nnmItem = await _context.NnmSubjects.FindAsync(id);
        if (nnmItem == null) return NotFound();
        return View(nnmItem);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,NnmSubjectName")] NnmSubject nnmItem)
    {
        if (id != nnmItem.Id) return NotFound();
        var current = await _context.NnmSubjects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (current == null) return NotFound();
        await ValidateAsync(nnmItem, id);
        if (ModelState.IsValid)
        {
            try
            {
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
        var nnmItem = await _context.NnmSubjects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (nnmItem == null) return NotFound();
        return View(nnmItem);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var nnmItem = await _context.NnmSubjects.FirstOrDefaultAsync(x => x.Id == id);
        if (nnmItem == null) return NotFound();
        if (await _context.NnmMarks.AnyAsync(m => m.NnmSubjectId == id))
        {
            ModelState.AddModelError("", "Môn học đang có điểm. Hãy xóa điểm trước khi xóa môn học.");
            return View("Delete", nnmItem);
        }

        try
        {
            _context.NnmSubjects.Remove(nnmItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Không thể xóa vì dữ liệu đang được sử dụng.");
            return View("Delete", nnmItem);
        }
    }

    private async Task ValidateAsync(NnmSubject nnmItem, int id)
    {
        nnmItem.NnmSubjectName = (nnmItem.NnmSubjectName ?? string.Empty).Trim();
        if (await _context.NnmSubjects.AnyAsync(s => s.Id != id && s.NnmSubjectName == nnmItem.NnmSubjectName))
            ModelState.AddModelError(nameof(nnmItem.NnmSubjectName), "Tên môn học đã tồn tại");
    }

}
