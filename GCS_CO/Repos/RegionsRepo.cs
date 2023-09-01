using GCS_CO.Models;
using GCS_CO.Data;

namespace GCS_CO.Repos
{
    public class RegionsRepo : IRegions
    {
        ApplicationDbContext context;

        public RegionsRepo(ApplicationDbContext c)
        {
            context = c;
        }
        public async Task<int> AddRegionAsync(Region region)
        {
            context.Regions.Add(region);
            return await context.SaveChangesAsync();
        }

        public async Task<Region> DeleteRegionAsync(int? id)
        {
            Region region = context.Regions.FirstOrDefault(r => r.RegionId == id);
            if (region != null)
            {
                context.Regions.Remove(region);
                await context.SaveChangesAsync();
            }

            return await Task.FromResult(region);
        }

        public async Task<IQueryable<Region>> GetAllRegionsAsync()
        {
            return await Task.FromResult<IQueryable<Region>>(context.Regions);
        }

        public async Task<Region> GetRegionAsync(int? id)
        {
            return await Task.FromResult<Region>(context.Regions.Find(id));
        }

        public bool RegionExists(int id)
        {
            var region = GetRegionAsync(id);
            if (region != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
