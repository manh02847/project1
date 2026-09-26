using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenNgocManh2410900051.Data;
using NguyenNgocManh2410900051.Models;

namespace NguyenNgocManh2410900051.Controllers;

public class NguyenNgocManhStudentsController : Controller
{
    private readonly ExamDbContext _context;

    public NguyenNgocManhStudentsController(ExamDbContext context) => _context = context;

    public async Task<IActionResult> Index(string? search)
    {
        ViewBag.Search = search;
        var students = _context.NguyenNgocManhStudents.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            students = students.Where(x =>
                x.NguyenNgocManhName.Contains(search) ||
                x.NguyenNgocManhGender.Contains(search) ||
                (x.NguyenNgocManhEmail != null && x.NguyenNgocManhEmail.Contains(search)) ||
                (x.NguyenNgocManhPhone != null && x.NguyenNgocManhPhone.Contains(search)));
        }

        return View(await students.OrderBy(x => x.Id).ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null) return NotFound();
        var student = await _context.NguyenNgocManhStudents.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return student is null ? NotFound() : View(student);
    }

    public IActionResult Create() => View(new NguyenNgocManhStudent());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,NguyenNgocManhName,NguyenNgocManhGender,NguyenNgocManhBirthDay,NguyenNgocManhEmail,NguyenNgocManhPhone,NguyenNgocManhActive")] NguyenNgocManhStudent student)
    {
        if (!ModelState.IsValid) return View(student);

        _context.Add(student);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null) return NotFound();
        var student = await _context.NguyenNgocManhStudents.FindAsync(id);
        return student is null ? NotFound() : View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,NguyenNgocManhName,NguyenNgocManhGender,NguyenNgocManhBirthDay,NguyenNgocManhEmail,NguyenNgocManhPhone,NguyenNgocManhActive")] NguyenNgocManhStudent student)
    {
        if (id != student.Id) return NotFound();
        if (!ModelState.IsValid) return View(student);

        try
        {
            _context.Update(student);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.NguyenNgocManhStudents.AnyAsync(x => x.Id == student.Id)) return NotFound();
            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) return NotFound();
        var student = await _context.NguyenNgocManhStudents.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return student is null ? NotFound() : View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var student = await _context.NguyenNgocManhStudents.FindAsync(id);
        if (student is null) return NotFound();

        _context.NguyenNgocManhStudents.Remove(student);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
