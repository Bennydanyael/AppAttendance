using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppAttendance.Data;
using AppAttendance.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppAttendance.Controllers
{
    public class WilayahController : Controller
    {
        private readonly AppDbContext _context;

        public WilayahController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Wilayah
        public async Task<IActionResult> Index()
        {
            return View(await _context.Wilayah.ToListAsync());
        }

        // GET: Wilayah/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wilayah = await _context.Wilayah
                .FirstOrDefaultAsync(m => m.Kd_wilayah == id);
            if (wilayah == null)
            {
                return NotFound();
            }

            return View(wilayah);
        }

        [Authorize]
        // GET: Wilayah/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wilayah/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Kd_wilayah,Nama_Wilayah")] Wilayah wilayah)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wilayah);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wilayah);
        }

        // GET: Wilayah/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wilayah = await _context.Wilayah.FindAsync(id);
            if (wilayah == null)
            {
                return NotFound();
            }
            return View(wilayah);
        }

        // POST: Wilayah/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Kd_wilayah,Nama_Wilayah")] Wilayah wilayah)
        {
            if (id != wilayah.Kd_wilayah)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wilayah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WilayahExists(wilayah.Kd_wilayah))
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
            return View(wilayah);
        }

        // GET: Wilayah/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wilayah = await _context.Wilayah
                .FirstOrDefaultAsync(m => m.Kd_wilayah == id);
            if (wilayah == null)
            {
                return NotFound();
            }

            return View(wilayah);
        }

        // POST: Wilayah/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wilayah = await _context.Wilayah.FindAsync(id);
            _context.Wilayah.Remove(wilayah);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WilayahExists(int id)
        {
            return _context.Wilayah.Any(e => e.Kd_wilayah == id);
        }
    }
}
