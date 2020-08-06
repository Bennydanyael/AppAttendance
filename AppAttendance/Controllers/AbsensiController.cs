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
    public class AbsensiController : Controller
    {
        private readonly AppDbContext _context;

        public AbsensiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Absensi
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Absensi.Include(a => a.Anggota).Include(a => a.Wilayah);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Absensi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absensi = await _context.Absensi
                .Include(a => a.Anggota)
                .Include(a => a.Wilayah)
                .FirstOrDefaultAsync(m => m.Kd_absen == id);
            if (absensi == null)
            {
                return NotFound();
            }

            return View(absensi);
        }

        // GET: Absensi/Create
        public IActionResult Create()
        {
            ViewData["Kd_anggota"] = new SelectList(_context.Anggota, "Kd_anggota", "Nama");
            ViewData["Kd_wilayah"] = new SelectList(_context.Wilayah, "Kd_wilayah", "Nama_Wilayah");
            return View();
        }

        // POST: Absensi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Kd_absen,Kd_anggota,Kd_wilayah,Keterangan,Tanggal,Selesai")] Absensi absensi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(absensi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Kd_anggota"] = new SelectList(_context.Anggota, "Kd_anggota", "Kd_anggota", absensi.Kd_anggota);
            ViewData["Kd_wilayah"] = new SelectList(_context.Wilayah, "Kd_wilayah", "Kd_wilayah", absensi.Kd_wilayah);
            return View(absensi);
        }

        // GET: Absensi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absensi = await _context.Absensi.FindAsync(id);
            if (absensi == null)
            {
                return NotFound();
            }
            ViewData["Kd_anggota"] = new SelectList(_context.Anggota, "Kd_anggota", "Nama", absensi.Kd_anggota);
            ViewData["Kd_wilayah"] = new SelectList(_context.Wilayah, "Kd_wilayah", "Kd_wilayah", absensi.Kd_wilayah);
            return View(absensi);
        }

        // POST: Absensi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Kd_absen,Kd_anggota,Kd_wilayah,Keterangan,Tanggal,Selesai")] Absensi absensi)
        {
            if (id != absensi.Kd_absen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(absensi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbsensiExists(absensi.Kd_absen))
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
            ViewData["Kd_anggota"] = new SelectList(_context.Anggota, "Kd_anggota", "Nama", absensi.Kd_anggota);
            ViewData["Kd_wilayah"] = new SelectList(_context.Wilayah, "Kd_wilayah", "Kd_wilayah", absensi.Kd_wilayah);
            return View(absensi);
        }

        // GET: Absensi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var absensi = await _context.Absensi
                .Include(a => a.Anggota)
                .Include(a => a.Wilayah)
                .FirstOrDefaultAsync(m => m.Kd_absen == id);
            if (absensi == null)
            {
                return NotFound();
            }

            return View(absensi);
        }

        // POST: Absensi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var absensi = await _context.Absensi.FindAsync(id);
            _context.Absensi.Remove(absensi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbsensiExists(int id)
        {
            return _context.Absensi.Any(e => e.Kd_absen == id);
        }
    }
}
