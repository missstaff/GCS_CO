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
    public class AddressTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddressTypes
        public async Task<IActionResult> Index()
        {
              return _context.AddressTypes != null ? 
                          View(await _context.AddressTypes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AddressTypes'  is null.");
        }


        // GET: AddressTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddressTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressTypeId,Type")] AddressType addressType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addressType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addressType);
        }

        // GET: AddressTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AddressTypes == null)
            {
                return NotFound();
            }

            var addressType = await _context.AddressTypes
                .FirstOrDefaultAsync(m => m.AddressTypeId == id);
            if (addressType == null)
            {
                return NotFound();
            }

            return View(addressType);
        }

        // POST: AddressTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AddressTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AddressTypes'  is null.");
            }
            var addressType = await _context.AddressTypes.FindAsync(id);
            if (addressType != null)
            {
                _context.AddressTypes.Remove(addressType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressTypeExists(int id)
        {
          return (_context.AddressTypes?.Any(e => e.AddressTypeId == id)).GetValueOrDefault();
        }
    }
}
