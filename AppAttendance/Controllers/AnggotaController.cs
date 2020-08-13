using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AppAttendance.Data;
using AppAttendance.Models;

namespace AppAttendance.Controllers
{
    public class AnggotaController : Controller
    {
        private readonly AppDbContext _context;

        public AnggotaController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Anggota
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Anggota.Include(a => a.Wilayah).Include(a => a.Pengurus);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Anggota/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anggota = await _context.Anggota
                .Include(a => a.Wilayah)
                .FirstOrDefaultAsync(m => m.Kd_anggota == id);
            if (anggota == null)
            {
                return NotFound();
            }

            return View(anggota);
        }

        [Authorize]
        // GET: Anggota/Create
        public IActionResult Create()
        {
            ViewData["Kd_wilayah"] = new SelectList(_context.Wilayah, "Kd_wilayah", "Nama_Wilayah");
            ViewData["IdPengurus"] = new SelectList(_context.Pengurus, "IdPengurus", "Username");
            return View();
        }

        // POST: Anggota/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Kd_anggota,Nama,Tgl_lahir,Alamat,Kd_wilayah,IdPengurus")] Anggota anggota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anggota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Kd_wilayah"] = new SelectList(_context.Wilayah, "Kd_wilayah", "Kd_wilayah", anggota.Kd_wilayah);
            ViewData["IdPengurus"] = new SelectList(_context.Pengurus, "IdPengurus", "IdPengurus", anggota.IdPengurus);
            return View(anggota);
        }

        // GET: Anggota/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anggota = await _context.Anggota.FindAsync(id);
            if (anggota == null)
            {
                return NotFound();
            }
            ViewData["Kd_wilayah"] = new SelectList(_context.Wilayah, "Kd_wilayah", "Kd_wilayah", anggota.Kd_wilayah);
            return View(anggota);
        }

        // POST: Anggota/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Kd_anggota,Nama,Tgl_lahir,Alamat,Kd_wilayah,Id_Pengurus")] Anggota anggota)
        {
            if (id != anggota.Kd_anggota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anggota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnggotaExists(anggota.Kd_anggota))
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
            ViewData["Kd_wilayah"] = new SelectList(_context.Wilayah, "Kd_wilayah", "Kd_wilayah", anggota.Kd_wilayah);
            return View(anggota);
        }

        // GET: Anggota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anggota = await _context.Anggota
                .Include(a => a.Wilayah)
                .FirstOrDefaultAsync(m => m.Kd_anggota == id);
            if (anggota == null)
            {
                return NotFound();
            }

            return View(anggota);
        }

        // POST: Anggota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anggota = await _context.Anggota.FindAsync(id);
            _context.Anggota.Remove(anggota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnggotaExists(int id)
        {
            return _context.Anggota.Any(e => e.Kd_anggota == id);
        }
    }
}
