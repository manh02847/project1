using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NnmLesson12EFCore.Data;
using NnmLesson12EFCore.Models;

namespace NnmLesson12EFCore.Controllers;

public class NnmMarksController : Controller
{
    private readonly NnmStudentDbContext _context;

    public NnmMarksController(NnmStudentDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.NnmMarks.Include(m => m.NnmStudent)
            .Include(m => m.NnmSubject).AsNoTracking().ToListAsync());
    }

    public async Task<IActionResult> Details(int? subjectId, int? studentId)
    {
        var nnmMark = await FindMarkAsync(subjectId, studentId);
        if (nnmMark == null) return NotFound();
        return View(nnmMark);
    }

    public IActionResult Create()
    {
        SetSelectLists();
        return View(new NnmMark());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("NnmSubjectId,NnmStudentId,NnmScore")] NnmMark nnmMark)
    {
        if (!await _context.NnmSubjects.AnyAsync(s => s.Id == nnmMark.NnmSubjectId))
            ModelState.AddModelError(nameof(nnmMark.NnmSubjectId), "Môn học không tồn tại");
        if (!await _context.NnmStudents.AnyAsync(s => s.Id == nnmMark.NnmStudentId))
            ModelState.AddModelError(nameof(nnmMark.NnmStudentId), "Sinh viên không tồn tại");
        if (await _context.NnmMarks.AnyAsync(m => m.NnmSubjectId == nnmMark.NnmSubjectId && m.NnmStudentId == nnmMark.NnmStudentId))
            ModelState.AddModelError("", "Sinh viên đã có điểm môn này. Hãy dùng chức năng sửa điểm.");

        if (ModelState.IsValid)
        {
            try
            {
                _context.NnmMarks.Add(nnmMark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Không thể lưu điểm. Kiểm tra điểm trùng hoặc dữ liệu liên quan đã thay đổi.");
            }
        }

        SetSelectLists(nnmMark);
        return View(nnmMark);
    }

    public async Task<IActionResult> Edit(int? subjectId, int? studentId)
    {
        var nnmMark = await FindMarkAsync(subjectId, studentId);
        if (nnmMark == null) return NotFound();
        return View(nnmMark);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int subjectId, int studentId,
        [Bind("NnmSubjectId,NnmStudentId,NnmScore")] NnmMark nnmMark)
    {
        if (subjectId != nnmMark.NnmSubjectId || studentId != nnmMark.NnmStudentId)
            return NotFound();
        var current = await FindMarkAsync(subjectId, studentId);
        if (current == null) return NotFound();

        if (ModelState.IsValid)
        {
            current.NnmScore = nnmMark.NnmScore;
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }

        current.NnmScore = nnmMark.NnmScore;
        return View(current);
    }

    public async Task<IActionResult> Delete(int? subjectId, int? studentId)
    {
        var nnmMark = await FindMarkAsync(subjectId, studentId);
        if (nnmMark == null) return NotFound();
        return View(nnmMark);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int subjectId, int studentId)
    {
        var nnmMark = await FindMarkAsync(subjectId, studentId);
        if (nnmMark == null) return NotFound();
        _context.NnmMarks.Remove(nnmMark);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private Task<NnmMark?> FindMarkAsync(int? subjectId, int? studentId)
    {
        return _context.NnmMarks.Include(m => m.NnmStudent).Include(m => m.NnmSubject)
            .FirstOrDefaultAsync(m => m.NnmSubjectId == subjectId && m.NnmStudentId == studentId);
    }

    private void SetSelectLists(NnmMark? nnmMark = null)
    {
        ViewData["NnmSubjectId"] = new SelectList(_context.NnmSubjects.OrderBy(s => s.NnmSubjectName),
            "Id", "NnmSubjectName", nnmMark?.NnmSubjectId);
        ViewData["NnmStudentId"] = new SelectList(_context.NnmStudents.OrderBy(s => s.NnmStudentName)
            .Select(s => new { s.Id, NnmLabel = s.NnmStudentName + " - " + s.NnmStudentEmail }),
            "Id", "NnmLabel", nnmMark?.NnmStudentId);
    }
}
