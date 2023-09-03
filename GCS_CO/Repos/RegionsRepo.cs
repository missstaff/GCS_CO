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

        public async Task DisassociateChildRecordsAsync(int regionId)
        {
            var region = await GetRegionAsync(regionId);
            if (region != null)
            {
                //Find and update related records to set Region property to null

                //States
                var relatedStates = context.States.Where(s => s.RegionAbbrev == region.RegionAbbrev);
                foreach (var state in relatedStates)
                {
                    state.Region = null;
                }

                //Postal Codes
                var relatedPostalCodes = context.PostalCodes.Where(pc => pc.RegionAbbrev == region.RegionAbbrev);
                foreach (var postalCode in relatedPostalCodes)
                {
                    postalCode.RegionAbbrev = null;
                }

                //Cities
                var relatedCities = context.Cities.Where(c => c.RegionAbbrev == region.RegionAbbrev);
                foreach (var city in relatedCities)
                {
                    city.RegionAbbrev = null;
                }

                //Addresses
                var relatedAddresses = context.Addresses.Where(a => a.RegionAbbrev == region.RegionAbbrev);
                foreach (var address in relatedAddresses)
                {
                    address.RegionAbbrev = null;
                }

                //Employees (if applicable)
                var relatedEmployees = context.Employees.Where(e => e.RegionAbbrev == region.RegionAbbrev);
                foreach (var employee in relatedEmployees)
                {
                    employee.Region = null;
                }

                await context.SaveChangesAsync();
            }
        }

    }
}
