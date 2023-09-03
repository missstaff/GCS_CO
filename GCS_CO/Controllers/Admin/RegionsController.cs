using Microsoft.AspNetCore.Mvc;
using GCS_CO.Models;
using Microsoft.AspNetCore.Authorization;
using GCS_CO.Repos;

namespace GCS_CO.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class RegionsController : Controller
    {
        private readonly IRegions repo;

        public RegionsController(IRegions r)
        {
            repo = r;
        }

        // GET: Regions
        public async Task<IActionResult> Index()
        {
            var regions = await repo.GetAllRegionsAsync();
            return View(regions);
        }

        // GET: Regions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await repo.GetRegionAsync(id);

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegionId,RegionAbbrev,RegionName")] Region region)
        {
            if (ModelState.IsValid)
            {
                await repo.AddRegionAsync(region);
                await repo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(region);
        }

        // GET: Regions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await repo.GetRegionAsync(id);

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
            var region = await repo.GetRegionAsync(id);
            if (region != null)
            {
                // Disassociate child records using the repository pattern
                await repo.DisassociateChildRecordsAsync(region.RegionId);

                await repo.DeleteRegionAsync(id);
            }

            await repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RegionExists(int id)
        {
            var state = await repo.GetRegionAsync(id);
            return state != null;
        }
    }
}
