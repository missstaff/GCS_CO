using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GCS_CO.Data;
using GCS_CO.Models;
using System.Drawing;

namespace GCS_CO.Controllers.Admin
{
    public class StatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: States
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.States.Include(s => s.Region);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: States/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.States == null)
            {
                return NotFound();
            }

            var state = await _context.States
                .Include(s => s.Region)
                .FirstOrDefaultAsync(m => m.StateId == id);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // GET: States/Create
        public IActionResult Create()
        {
            ViewData["RegionAbbrev"] = new SelectList(_context.Regions, "RegionAbbrev", "RegionAbbrev");
            return View();
        }

        // POST: States/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StateId,StateAbbrev,StateName,RegionAbbrev")] State state)
        {
            if (ModelState.IsValid)
            {
                _context.Add(state);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionAbbrev"] = new SelectList(_context.Regions, "RegionAbbrev", "RegionAbbrev", state.RegionAbbrev);
            return View(state);
        }

        // GET: States/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.States == null)
            {
                return NotFound();
            }

            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }
            ViewData["RegionAbbrev"] = new SelectList(_context.Regions, "RegionAbbrev", "RegionAbbrev", state.RegionAbbrev);
            return View(state);
        }

        // POST: States/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StateId,StateAbbrev,StateName,RegionAbbrev")] State state)
        {
            if (id != state.StateId)
            {
                return NotFound();
            }
           

            if (ModelState.IsValid)
            {
                try
                {
                    var postalCodesToUpdate = await _context.PostalCodes.Where(e => e.StateAbbrev == state.StateAbbrev).ToListAsync();
                    foreach (var postalCode in postalCodesToUpdate)
                    {
                        postalCode.RegionAbbrev = state.RegionAbbrev;
                    }

                    var citiesToUpdate = await _context.Cities.Where(e => e.StateAbbrev == state.StateAbbrev).ToListAsync();
                    foreach (var city in citiesToUpdate)
                    {
                        city.RegionAbbrev = state.RegionAbbrev;
                    }

                    var addressesToUpdate = await _context.Addresses.Where(e => e.StateAbbrev == state.StateAbbrev).ToListAsync();
                    foreach (var address in addressesToUpdate)
                    {
                        address.RegionAbbrev = state.RegionAbbrev;
                    }

                    _context.Update(state);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StateExists(state.StateId))
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
            ViewData["RegionAbbrev"] = new SelectList(_context.Regions, "RegionAbbrev", "RegionAbbrev", state.RegionAbbrev);
            return View(state);
        }

        // GET: States/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.States == null)
            {
                return NotFound();
            }

            var state = await _context.States
                .Include(s => s.Region)
                .FirstOrDefaultAsync(m => m.StateId == id);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.States == null)
            {
                return Problem("Entity set 'ApplicationDbContext.States'  is null.");
            }
            var state = await _context.States.FindAsync(id);
            if (state != null)
            {
                _context.States.Remove(state);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StateExists(int id)
        {
          return (_context.States?.Any(e => e.StateId == id)).GetValueOrDefault();
        }
    }
}
