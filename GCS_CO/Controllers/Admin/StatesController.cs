using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GCS_CO.Models;
using Microsoft.AspNetCore.Authorization;
using GCS_CO.Repos;

namespace GCS_CO.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class StatesController : Controller
    {
        IStates repo;

        public StatesController(IStates r)
        {
            repo = r;
        }
        // GET: States
        public async Task<IActionResult> Index()
        {
            return repo.GetAllStatesAsync != null ?
                          View(await repo.GetAllStatesAsync()) :
                          Problem("Entity set 'ApplicationDbContext.States'  is null.");
        }

        // GET: States/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await repo.GetStateAsync(id);

            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // GET: States/Create
        public async Task<IActionResult> Create()
        {
            var regionAbbrevs = await repo.GetDistinctRegionAbbrevAsync();
            ViewData["RegionAbbrev"] = new SelectList(regionAbbrevs);

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
                await repo.AddStateAsync(state);
                await repo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var regionAbbrevs = await repo.GetDistinctRegionAbbrevAsync();
            ViewData["RegionAbbrev"] = new SelectList(regionAbbrevs, "RegionAbbrev", "RegionAbbrev", state.RegionAbbrev);
            return View(state);
        }

        // GET: States/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || repo.GetAllStatesAsync() == null)
            {
                return NotFound();
            }

            var state = await repo.GetStateAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            // Retrieve all states for the SelectList
            var allStates = await repo.GetAllStatesAsync();

            // Populate ViewBag.RegionAbbrev with a SelectList using all states
            ViewBag.RegionAbbrev = new SelectList(allStates, "RegionAbbrev", "RegionAbbrev", state.RegionAbbrev);

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
                    //var postalCodesToUpdate = await repo.PostalCodes.Where(e => e.StateAbbrev == state.StateAbbrev).ToListAsync();
                    //foreach (var postalCode in postalCodesToUpdate)
                    //{
                    //    postalCode.RegionAbbrev = state.RegionAbbrev;
                    //}

                    //var citiesToUpdate = await _context.Cities.Where(e => e.StateAbbrev == state.StateAbbrev).ToListAsync();
                    //foreach (var city in citiesToUpdate)
                    //{
                    //    city.RegionAbbrev = state.RegionAbbrev;
                    //}

                    //var addressesToUpdate = await _context.Addresses.Where(e => e.StateAbbrev == state.StateAbbrev).ToListAsync();
                    //foreach (var address in addressesToUpdate)
                    //{
                    //    address.RegionAbbrev = state.RegionAbbrev;
                    //}

                    repo.UpdateStateAsync(state, id);
                    await repo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exists = await StateExists(state.StateId);
                    if (exists)
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
            var regionAbbrevs = await repo.GetDistinctRegionAbbrevAsync();
            ViewData["RegionAbbrev"] = new SelectList(regionAbbrevs, "RegionAbbrev", "RegionAbbrev", state.RegionAbbrev);
            return View(state);
        }

        // GET: States/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await repo.GetStateAsync(id);
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
            var state = await repo.GetStateAsync(id);
            if (state != null)
            {
                var addresses = await repo.GetAddressesForStateAsync(state.StateAbbrev);
                var postalCodes = await repo.GetPostalCodesForStateAsync(state.StateAbbrev);
                if (postalCodes.Any() || addresses.Any())
                {
                    //You can use TempData to store a message and display it after redirect
                    TempData["DeleteErrorMessage"] = "Cannot delete this state because it has associated records.";

                    return RedirectToAction(nameof(Index));
                }

                await repo.DeleteStateAsync(id);
            }
            
            await repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> StateExists(int id)
        {
            var state = await repo.GetStateAsync(id);
            return state != null;
        }
    }
}
