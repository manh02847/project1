using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenNgocManh2410900051.Data;
using NguyenNgocManh2410900051.Models;

namespace NguyenNgocManh2410900051.Controllers
{
    public class NguyenNgocManhEmployeesController : Controller
    {
        private readonly ExamDbContext _context;

        public NguyenNgocManhEmployeesController(ExamDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.NguyenNgocManhEmployees.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenNgocManhEmployee = await _context.NguyenNgocManhEmployees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nguyenNgocManhEmployee == null)
            {
                return NotFound();
            }

            return View(nguyenNgocManhEmployee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NguyenNgocManhName,NguyenNgocManhGender,NguyenNgocManhBirthDay,NguyenNgocManhEmail,NguyenNgocManhPhone,NguyenNgocManhActive")] NguyenNgocManhEmployee nguyenNgocManhEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguyenNgocManhEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nguyenNgocManhEmployee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenNgocManhEmployee = await _context.NguyenNgocManhEmployees.FindAsync(id);
            if (nguyenNgocManhEmployee == null)
            {
                return NotFound();
            }
            return View(nguyenNgocManhEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NguyenNgocManhName,NguyenNgocManhGender,NguyenNgocManhBirthDay,NguyenNgocManhEmail,NguyenNgocManhPhone,NguyenNgocManhActive")] NguyenNgocManhEmployee nguyenNgocManhEmployee)
        {
            if (id != nguyenNgocManhEmployee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguyenNgocManhEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguyenNgocManhEmployeeExists(nguyenNgocManhEmployee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nguyenNgocManhEmployee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenNgocManhEmployee = await _context.NguyenNgocManhEmployees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nguyenNgocManhEmployee == null)
            {
                return NotFound();
            }

            return View(nguyenNgocManhEmployee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguyenNgocManhEmployee = await _context.NguyenNgocManhEmployees.FindAsync(id);
            if (nguyenNgocManhEmployee != null)
            {
                _context.NguyenNgocManhEmployees.Remove(nguyenNgocManhEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguyenNgocManhEmployeeExists(int id)
        {
            return _context.NguyenNgocManhEmployees.Any(e => e.Id == id);
        }
    }
}
