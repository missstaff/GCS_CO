using GCS_CO.Models;

namespace GCS_CO.Repos
{
    public interface IRegions
    {
        public Task<IQueryable<Region>> GetAllRegionsAsync();
        public Task<Region> GetRegionAsync(int? id);
        public Task<int> AddRegionAsync(Region region);
        public Task<Region> DeleteRegionAsync(int? id);
        public Task DisassociateChildRecordsAsync(int id);
        public bool RegionExists(int id);
        public Task SaveChangesAsync();
    }
}
