using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GCS_CO.Data;
using GCS_CO.Models;
using System.Net;
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

            var ids = id.Split('-');
            if (ids.Length != 2)
            {
                return NotFound();
            }

            var cityName = ids[0];
            var stateAbbrev = ids[1];

            var postalCode = await _context.PostalCodes
              .Include(p => p.State)
              .FirstOrDefaultAsync(m => m.CityName == cityName && m.StateAbbrev == stateAbbrev);
            if (postalCode == null)
            {
                return NotFound();
            }

            return View(postalCode);
        }

        // GET: PostalCodes/Create
        public IActionResult Create()
        {
            ViewData["StateAbbrev"] = new SelectList(_context.Cities, "StateAbbrev", "StateAbbrev");
            ViewData["RegionAbbrev"] = new SelectList(_context.Regions, "RegionAbbrev", "RegionAbbrev");
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

                var existingCity = _context.Cities.FirstOrDefault(c => c.CityName == postalCode.CityName && c.StateAbbrev == postalCode.StateAbbrev);
                if (existingCity == null)
                {
                    var newCity = new City
                    {
                        CityName = postalCode.CityName,
                        StateAbbrev = postalCode.StateAbbrev,
                        RegionAbbrev = postalCode.RegionAbbrev,
                        Code = postalCode.Code,
                    };
                    _context.Cities.Add(newCity);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["StateAbbrev"] = new SelectList(_context.States, "StateAbbrev", "StateAbbrev", postalCode.StateAbbrev);
            ViewData["RegionAbbrev"] = new SelectList(_context.States, "RegionAbbrev", "RegionAbbrev", postalCode.RegionAbbrev);
            return View(postalCode);
        }

        // GET: PostalCodes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.PostalCodes == null)
            {
                return NotFound();
            }

            var ids = id.Split('-');
            if (ids.Length != 2)
            {
                return NotFound();
            }

            var cityName = ids[0];
            var stateAbbrev = ids[1];

            var postalCode = await _context.PostalCodes
                .Include(p => p.State)
                .FirstOrDefaultAsync(m => m.CityName == cityName && m.StateAbbrev == stateAbbrev);

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
            //set admin task to update all user's addresses effetcted by this delete and make sure the admin has a list of employees to contact
            if (_context.PostalCodes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PostalCodes'  is null.");
            }

            var ids = id.Split('-');
            if (ids.Length != 2)
            {
                return NotFound();
            }

            var cityName = ids[0];
            var stateAbbrev = ids[1];

            var postalCode = await _context.PostalCodes
              .Include(p => p.State)
              .FirstOrDefaultAsync(m => m.CityName == cityName && m.StateAbbrev == stateAbbrev);

            if (postalCode != null)
            {
                _context.PostalCodes.Remove(postalCode);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostalCodeExists(string id)
        {
            var ids = id.Split('-');
            var cityName = ids[0];
            var stateAbbrev = ids[1];
            return (_context.PostalCodes?.Any(e => e.CityName == cityName && e.StateAbbrev == stateAbbrev)).GetValueOrDefault();
        }
    }
}
