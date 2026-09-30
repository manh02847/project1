using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NnmLesson12EFCore.Data;
using NnmLesson12EFCore.Helpers;
using NnmLesson12EFCore.Models;

namespace NnmLesson12EFCore.Controllers;

public class NnmStudentsController : Controller
{
    private readonly NnmStudentDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public NnmStudentsController(NnmStudentDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.NnmStudents.Include(x => x.NnmClass).AsNoTracking().ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var nnmItem = await _context.NnmStudents.Include(x => x.NnmClass).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (nnmItem == null) return NotFound();
        return View(nnmItem);
    }

    public IActionResult Create()
    {
        SetSelectList();
        return View(new NnmStudent());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("NnmStudentName,NnmStudentEmail,NnmStudentPhone,NnmStudentAddress,NnmStudentBirthday,NnmClassId")] NnmStudent nnmItem, IFormFile? NnmUpload)
    {
        await ValidateAsync(nnmItem, 0);
        ValidateImage(NnmUpload, true);
        if (ModelState.IsValid)
        {
            try
            {
                nnmItem.NnmStudentAvatar = await NnmImageUpload.SaveAsync(NnmUpload!, _environment.WebRootPath, "Student");
                _context.Add(nnmItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Không thể lưu dữ liệu. Kiểm tra dữ liệu trùng hoặc dữ liệu liên quan đã thay đổi.");
            }
        }
        SetSelectList(nnmItem.NnmClassId);
        return View(nnmItem);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var nnmItem = await _context.NnmStudents.FindAsync(id);
        if (nnmItem == null) return NotFound();
        SetSelectList(nnmItem.NnmClassId);
        return View(nnmItem);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,NnmStudentName,NnmStudentEmail,NnmStudentPhone,NnmStudentAddress,NnmStudentBirthday,NnmClassId")] NnmStudent nnmItem, IFormFile? NnmUpload)
    {
        if (id != nnmItem.Id) return NotFound();
        var current = await _context.NnmStudents.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (current == null) return NotFound();
        await ValidateAsync(nnmItem, id);
        nnmItem.NnmStudentAvatar = current.NnmStudentAvatar;
        ValidateImage(NnmUpload, false);
        if (ModelState.IsValid)
        {
            try
            {
                if (NnmUpload != null && NnmUpload.Length > 0)
                    nnmItem.NnmStudentAvatar = await NnmImageUpload.SaveAsync(NnmUpload, _environment.WebRootPath, "Student");
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
        SetSelectList(nnmItem.NnmClassId);
        return View(nnmItem);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var nnmItem = await _context.NnmStudents.Include(x => x.NnmClass).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (nnmItem == null) return NotFound();
        return View(nnmItem);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var nnmItem = await _context.NnmStudents.Include(x => x.NnmClass).FirstOrDefaultAsync(x => x.Id == id);
        if (nnmItem == null) return NotFound();
        if (await _context.NnmMarks.AnyAsync(m => m.NnmStudentId == id))
        {
            ModelState.AddModelError("", "Sinh viên đã có điểm. Hãy xóa điểm trước khi xóa sinh viên.");
            return View("Delete", nnmItem);
        }

        try
        {
            _context.NnmStudents.Remove(nnmItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Không thể xóa vì dữ liệu đang được sử dụng.");
            return View("Delete", nnmItem);
        }
    }

    private async Task ValidateAsync(NnmStudent nnmItem, int id)
    {
        nnmItem.NnmStudentEmail = (nnmItem.NnmStudentEmail ?? string.Empty).Trim();
        nnmItem.NnmStudentPhone = (nnmItem.NnmStudentPhone ?? string.Empty).Trim();
        if (await _context.NnmStudents.AnyAsync(s => s.Id != id && s.NnmStudentEmail == nnmItem.NnmStudentEmail))
            ModelState.AddModelError(nameof(nnmItem.NnmStudentEmail), "Email đã được sử dụng");
        if (await _context.NnmStudents.AnyAsync(s => s.Id != id && s.NnmStudentPhone == nnmItem.NnmStudentPhone))
            ModelState.AddModelError(nameof(nnmItem.NnmStudentPhone), "Số điện thoại đã được sử dụng");
        if (nnmItem.NnmStudentBirthday.Date > DateTime.Today)
            ModelState.AddModelError(nameof(nnmItem.NnmStudentBirthday), "Ngày sinh không được ở tương lai");
        if (!await _context.NnmStdClasses.AnyAsync(c => c.Id == nnmItem.NnmClassId))
            ModelState.AddModelError(nameof(nnmItem.NnmClassId), "Lớp học không tồn tại");
    }

    private void SetSelectList(int? selected = null)
    {
        ViewData["NnmClassId"] = new SelectList(_context.NnmStdClasses.OrderBy(x => x.NnmClassName), "Id", "NnmClassName", selected);
    }

    private void ValidateImage(IFormFile? file, bool required)
    {
        var error = NnmImageUpload.Validate(file, required);
        if (error != null)
            ModelState.AddModelError("NnmUpload", error);
    }
}
