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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GCS_CO.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class RegionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Regions
        public async Task<IActionResult> Index()
        {
              return _context.Regions != null ? 
                          View(await _context.Regions.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Regions'  is null.");
        }

        // GET: Regions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Regions == null)
            {
                return NotFound();
            }

            var region = await _context.Regions
                .FirstOrDefaultAsync(m => m.RegionId == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // GET: Regions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegionId,RegionAbbrev,RegionName")] Region region)
        {
            if (ModelState.IsValid)
            {
                _context.Add(region);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(region);
        }


        // GET: Regions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Regions == null)
            {
                return NotFound();
            }

            var region = await _context.Regions
                .FirstOrDefaultAsync(m => m.RegionId == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Regions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Regions'  is null.");
            }
            var region = await _context.Regions.FindAsync(id);
            if (region != null)
            {
                var statesToUpdate = await _context.States.Where(s => s.RegionAbbrev == region.RegionAbbrev).ToListAsync();
                foreach (var state in statesToUpdate)
                {
                    state.RegionAbbrev = null;
                }

                var postalCodesToUpdate = await _context.PostalCodes.Where(e => e.RegionAbbrev == region.RegionAbbrev).ToListAsync();
                foreach (var postalCode in postalCodesToUpdate)
                {
                    postalCode.RegionAbbrev = null;
                }

                var citiesToUpdate = await _context.Cities.Where(e => e.RegionAbbrev == region.RegionAbbrev).ToListAsync();
                foreach (var city in citiesToUpdate)
                {
                    city.RegionAbbrev = null;
                }

                var addressesToUpdate = await _context.Addresses.Where(e => e.RegionAbbrev == region.RegionAbbrev).ToListAsync();
                foreach (var address in addressesToUpdate)
                {
                    address.RegionAbbrev = null;
                }

                var employeeesToUpdate = await _context.Employees.Where(e => e.RegionAbbrev == region.RegionAbbrev).ToListAsync();
                foreach (var employee in employeeesToUpdate)
                {
                    employee.RegionAbbrev = null;
                }
                //TODO: customer region set to null
                _context.Regions.Remove(region);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegionExists(int id)
        {
          return (_context.Regions?.Any(e => e.RegionId == id)).GetValueOrDefault();
        }
    }
}
