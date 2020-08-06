using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppAttendance.Data;
using AppAttendance.Models;

namespace AppAttendance.Controllers
{
    public class PengurusController : Controller
    {
        private readonly AppDbContext _context;

        public PengurusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pengurus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pengurus.ToListAsync());
        }

        // GET: Pengurus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pengurus = await _context.Pengurus
                .FirstOrDefaultAsync(m => m.IdPengurus == id);
            if (pengurus == null)
            {
                return NotFound();
            }

            return View(pengurus);
        }

        // GET: Pengurus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pengurus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPengurus,Username,Passwords")] Pengurus pengurus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pengurus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pengurus);
        }

        // GET: Pengurus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pengurus = await _context.Pengurus.FindAsync(id);
            if (pengurus == null)
            {
                return NotFound();
            }
            return View(pengurus);
        }

        // POST: Pengurus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPengurus,Username,Passwords")] Pengurus pengurus)
        {
            if (id != pengurus.IdPengurus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pengurus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PengurusExists(pengurus.IdPengurus))
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
            return View(pengurus);
        }

        // GET: Pengurus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pengurus = await _context.Pengurus
                .FirstOrDefaultAsync(m => m.IdPengurus == id);
            if (pengurus == null)
            {
                return NotFound();
            }

            return View(pengurus);
        }

        // POST: Pengurus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pengurus = await _context.Pengurus.FindAsync(id);
            _context.Pengurus.Remove(pengurus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PengurusExists(int id)
        {
            return _context.Pengurus.Any(e => e.IdPengurus == id);
        }
    }
}
