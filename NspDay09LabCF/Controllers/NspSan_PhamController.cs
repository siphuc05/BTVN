using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NspDay09LabCF.Models;

namespace NspDay09LabCF.Controllers
{
    public class NspSan_PhamController : Controller
    {
        private readonly NspDay09LabCFContext _context;

        public NspSan_PhamController(NspDay09LabCFContext context)
        {
            _context = context;
        }

        // GET: NspSan_Pham
        public async Task<IActionResult> Index()
        {
            return View(await _context.nspSan_Phams.ToListAsync());
        }

        // GET: NspSan_Pham/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nspSan_Pham = await _context.nspSan_Phams
                .FirstOrDefaultAsync(m => m.nspId == id);
            if (nspSan_Pham == null)
            {
                return NotFound();
            }

            return View(nspSan_Pham);
        }

        // GET: NspSan_Pham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NspSan_Pham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nspId,nspMaSanPham,nspTenSanPham,nspHinhAnh,nspSoLuong,nspDonGia,nspLoaiSanPhamId")] NspSan_Pham nspSan_Pham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nspSan_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nspSan_Pham);
        }

        // GET: NspSan_Pham/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nspSan_Pham = await _context.nspSan_Phams.FindAsync(id);
            if (nspSan_Pham == null)
            {
                return NotFound();
            }
            return View(nspSan_Pham);
        }

        // POST: NspSan_Pham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("nspId,nspMaSanPham,nspTenSanPham,nspHinhAnh,nspSoLuong,nspDonGia,nspLoaiSanPhamId")] NspSan_Pham nspSan_Pham)
        {
            if (id != nspSan_Pham.nspId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nspSan_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NspSan_PhamExists(nspSan_Pham.nspId))
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
            return View(nspSan_Pham);
        }

        // GET: NspSan_Pham/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nspSan_Pham = await _context.nspSan_Phams
                .FirstOrDefaultAsync(m => m.nspId == id);
            if (nspSan_Pham == null)
            {
                return NotFound();
            }

            return View(nspSan_Pham);
        }

        // POST: NspSan_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var nspSan_Pham = await _context.nspSan_Phams.FindAsync(id);
            if (nspSan_Pham != null)
            {
                _context.nspSan_Phams.Remove(nspSan_Pham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NspSan_PhamExists(long id)
        {
            return _context.nspSan_Phams.Any(e => e.nspId == id);
        }
    }
}
