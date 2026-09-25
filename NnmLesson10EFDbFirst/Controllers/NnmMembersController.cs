using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NnmLesson10EFDbFirst.Models;

namespace NnmLesson10EFDbFirst.Controllers
{
    public class NnmMembersController : Controller
    {
        private readonly NnmK24cnt2lesson10EfdbContext _context;

        public NnmMembersController(NnmK24cnt2lesson10EfdbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.NnmMembers.ToListAsync());
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nnmMember = await _context.NnmMembers
                .FirstOrDefaultAsync(m => m.Id == id);

            if (nnmMember == null)
            {
                return NotFound();
            }

            return View(nnmMember);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,NnmUserName,NnmPassword,NnmFullName,NnmEmail,NnmPhone,NnmStatus")] NnmMember nnmMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nnmMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(nnmMember);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nnmMember = await _context.NnmMembers.FindAsync(id);

            if (nnmMember == null)
            {
                return NotFound();
            }

            return View(nnmMember);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            long id,
            [Bind("Id,NnmUserName,NnmPassword,NnmFullName,NnmEmail,NnmPhone,NnmStatus")] NnmMember nnmMember)
        {
            if (id != nnmMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nnmMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NnmMemberExists(nnmMember.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(nnmMember);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nnmMember = await _context.NnmMembers
                .FirstOrDefaultAsync(m => m.Id == id);

            if (nnmMember == null)
            {
                return NotFound();
            }

            return View(nnmMember);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var nnmMember = await _context.NnmMembers.FindAsync(id);

            if (nnmMember != null)
            {
                _context.NnmMembers.Remove(nnmMember);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NnmMemberExists(long id)
        {
            return _context.NnmMembers.Any(e => e.Id == id);
        }
    }
}
