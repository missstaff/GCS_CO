using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GCS_CO.Data;
using GCS_CO.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace GCS_CO.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class PostalCodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostalCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostalCodes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PostalCodes.Include(p => p.State);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PostalCodes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.PostalCodes == null)
            {
                return NotFound();
            }

            var postalCode = await _context.PostalCodes
                .Include(p => p.State)
                .FirstOrDefaultAsync(m => m.CityName == id);
            if (postalCode == null)
            {
                return NotFound();
            }

            return View(postalCode);
        }

        // GET: PostalCodes/Create
        public IActionResult Create()
        {
            ViewData["StateAbbrev"] = new SelectList(_context.States, "StateAbbrev", "RegionAbbrev");
            return View();
        }

        // POST: PostalCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityName,Code,StateAbbrev,RegionAbbrev")] PostalCode postalCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postalCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateAbbrev"] = new SelectList(_context.States, "StateAbbrev", "RegionAbbrev", postalCode.StateAbbrev);
            return View(postalCode);
        }

        // GET: PostalCodes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.PostalCodes == null)
            {
                return NotFound();
            }

            var postalCode = await _context.PostalCodes.FindAsync(id);
            if (postalCode == null)
            {
                return NotFound();
            }
            ViewData["StateAbbrev"] = new SelectList(_context.States, "StateAbbrev", "RegionAbbrev", postalCode.StateAbbrev);
            return View(postalCode);
        }

        // POST: PostalCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CityName,Code,StateAbbrev,RegionAbbrev")] PostalCode postalCode)
        {
            if (id != postalCode.CityName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postalCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostalCodeExists(postalCode.CityName))
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
            ViewData["StateAbbrev"] = new SelectList(_context.States, "StateAbbrev", "RegionAbbrev", postalCode.StateAbbrev);
            return View(postalCode);
        }

        // GET: PostalCodes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.PostalCodes == null)
            {
                return NotFound();
            }

            var postalCode = await _context.PostalCodes
                .Include(p => p.State)
                .FirstOrDefaultAsync(m => m.CityName == id);
            if (postalCode == null)
            {
                return NotFound();
            }

            return View(postalCode);
        }

        // POST: PostalCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.PostalCodes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PostalCodes'  is null.");
            }
            var postalCode = await _context.PostalCodes.FindAsync(id);
            if (postalCode != null)
            {
                _context.PostalCodes.Remove(postalCode);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostalCodeExists(string id)
        {
          return (_context.PostalCodes?.Any(e => e.CityName == id)).GetValueOrDefault();
        }
    }
}
