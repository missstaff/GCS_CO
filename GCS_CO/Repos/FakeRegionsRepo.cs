using GCS_CO.Models;

namespace GCS_CO.Repos
{
    public class FakeRegionsRepo : IRegions
    {
        private List<Region> regions = new List<Region>();

        public List<Region> Regions { get { return regions; } }
        public Task<int> AddRegionAsync(Region region)
        {
            int success = 0;
            if (region != null)
            {

                region.RegionId = regions.Count + 1;
                regions.Add(region);
                success = 1;
            }

            return Task.FromResult<int>(success);
        }

        public Task<Region> DeleteRegionAsync(int? id)
        {
            var region = regions.Find(r => r.RegionId == id);
            regions.Remove(region);
            return Task.FromResult<Region>(region);
        }

        public Task DisassociateChildRecordsAsync(int id)
        {
            return Task.CompletedTask;
        }

        public Task<IQueryable<Region>> GetAllRegionsAsync()
        {
            return Task.FromResult(regions.AsQueryable());
        }

        public Task<Region> GetRegionAsync(int? id)
        {
            var region = regions.Find(r => r.RegionId == id);
            return Task.FromResult(region);
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
            return SaveChangesAsync();
        }
    }
}
