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

namespace GCS_CO.Controllers.Admin
{
    public class AddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Addresses.Include(a => a.AddressType).Include(a => a.City).Include(a => a.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Addresses == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.AddressType)
                .Include(a => a.City)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.AddressId == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            ViewData["Type"] = new SelectList(_context.AddressTypes, "Type", "Type");
            ViewData["CityName"] = new SelectList(_context.Cities, "CityName", "CityName");
            ViewData["StateAbbrev"] = new SelectList(_context.Cities, "StateAbbrev", "StateAbbrev");
            ViewData["RegionAbbrev"] = new SelectList(_context.Cities, "RegionAbbrev", "RegionAbbrev");
            ViewData["PostalCode"] = new SelectList(_context.Cities, "Code", "Code");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressId,EmployeeId,Street,CityName,StateAbbrev,PostalCode,RegionAbbrev,Type")] Address address)
        {
            var city = await _context.PostalCodes.FirstOrDefaultAsync(a => a.CityName == address.CityName && a.StateAbbrev == address.StateAbbrev);
            if (city == null)
            {
                return NotFound();
            }

            var newAddress = new Address
            {
                EmployeeId = address.EmployeeId,
                Street = address.Street,
                CityName = address.CityName,
                StateAbbrev = address.StateAbbrev,
                PostalCode = city.Code,
                RegionAbbrev = city.RegionAbbrev,
                Type = address.Type
            };
            if (ModelState.IsValid)
            {
                _context.Add(newAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Type"] = new SelectList(_context.AddressTypes, "Type", "Type", address.Type);
            ViewData["CityName"] = new SelectList(_context.Cities, "CityName", "CityName", address.CityName);
            ViewData["StateAbbrev"] = new SelectList(_context.Cities, "StateAbbrev", "StateAbbrev", address.StateAbbrev);
            ViewData["RegionAbbrev"] = new SelectList(_context.Cities, "RegionAbbrev", "RegionAbbrev", address.RegionAbbrev);
            ViewData["PostalCode"] = new SelectList(_context.Cities, "Code", "Code", address.PostalCode);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", address.EmployeeId);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Addresses == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["Type"] = new SelectList(_context.AddressTypes, "Type", "Type", address.Type);
            ViewData["CityName"] = new SelectList(_context.Cities, "CityName", "CityName", address.CityName);
            ViewData["StateAbbrev"] = new SelectList(_context.Cities, "StateAbbrev", "StateAbbrev", address.StateAbbrev);
            ViewData["RegionAbbrev"] = new SelectList(_context.Cities, "RegionAbbrev", "RegionAbbrev", address.RegionAbbrev);
            ViewData["PostalCode"] = new SelectList(_context.Cities, "Code", "Code", address.PostalCode);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", address.EmployeeId);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressId,EmployeeId,Street,CityName,StateAbbrev,PostalCode,RegionAbbrev,Type")] Address address)
        {

            if (id != address.AddressId)
            {
                return NotFound();
            }
            var city = await _context.PostalCodes.FirstOrDefaultAsync(a => a.CityName == address.CityName && a.StateAbbrev == address.StateAbbrev);
            if (city == null)
            {
                return NotFound();
            }

            var newAddress = new Address
            {
                EmployeeId = address.EmployeeId,
                Street = address.Street,
                CityName = address.CityName,
                StateAbbrev = address.StateAbbrev,
                PostalCode = city.Code,
                RegionAbbrev = city.RegionAbbrev,
                Type = address.Type
            };

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.AddressId))
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
            ViewData["Type"] = new SelectList(_context.AddressTypes, "Type", "Type", address.Type);
            ViewData["CityName"] = new SelectList(_context.Cities, "CityName", "CityName", address.CityName);
            ViewData["StateAbbrev"] = new SelectList(_context.Cities, "StateAbbrev", "StateAbbrev", address.StateAbbrev);
            ViewData["RegionAbbrev"] = new SelectList(_context.Regions, "RegionAbbrev", "RegionAbbrev", address.RegionAbbrev);
            ViewData["PostalCode"] = new SelectList(_context.Cities, "Code", "Code", address.PostalCode);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", address.EmployeeId);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Addresses == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.AddressType)
                .Include(a => a.City)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.AddressId == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Addresses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Addresses'  is null.");
            }
            var address = await _context.Addresses.FindAsync(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
          return (_context.Addresses?.Any(e => e.AddressId == id)).GetValueOrDefault();
        }
    }
}
