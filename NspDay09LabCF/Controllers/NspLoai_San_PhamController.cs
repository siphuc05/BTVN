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
    public class NspLoai_San_PhamController : Controller
    {
        private readonly NspDay09LabCFContext _context;

        public NspLoai_San_PhamController(NspDay09LabCFContext context)
        {
            _context = context;
        }

        // GET: NspLoai_San_Pham
        public async Task<IActionResult> Index()
        {
            return View(await _context.nspLoai_San_Phams.ToListAsync());
        }

        // GET: NspLoai_San_Pham/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nspLoai_San_Pham = await _context.nspLoai_San_Phams
                .FirstOrDefaultAsync(m => m.nspId == id);
            if (nspLoai_San_Pham == null)
            {
                return NotFound();
            }

            return View(nspLoai_San_Pham);
        }

        // GET: NspLoai_San_Pham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NspLoai_San_Pham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nspId,nspMaLoai,nspTenLoai,nspTrangThai")] NspLoai_San_Pham nspLoai_San_Pham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nspLoai_San_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nspLoai_San_Pham);
        }

        // GET: NspLoai_San_Pham/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nspLoai_San_Pham = await _context.nspLoai_San_Phams.FindAsync(id);
            if (nspLoai_San_Pham == null)
            {
                return NotFound();
            }
            return View(nspLoai_San_Pham);
        }

        // POST: NspLoai_San_Pham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("nspId,nspMaLoai,nspTenLoai,nspTrangThai")] NspLoai_San_Pham nspLoai_San_Pham)
        {
            if (id != nspLoai_San_Pham.nspId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nspLoai_San_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NspLoai_San_PhamExists(nspLoai_San_Pham.nspId))
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
            return View(nspLoai_San_Pham);
        }

        // GET: NspLoai_San_Pham/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nspLoai_San_Pham = await _context.nspLoai_San_Phams
                .FirstOrDefaultAsync(m => m.nspId == id);
            if (nspLoai_San_Pham == null)
            {
                return NotFound();
            }

            return View(nspLoai_San_Pham);
        }

        // POST: NspLoai_San_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var nspLoai_San_Pham = await _context.nspLoai_San_Phams.FindAsync(id);
            if (nspLoai_San_Pham != null)
            {
                _context.nspLoai_San_Phams.Remove(nspLoai_San_Pham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NspLoai_San_PhamExists(long id)
        {
            return _context.nspLoai_San_Phams.Any(e => e.nspId == id);
        }
    }
}
