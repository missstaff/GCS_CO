using GCS_CO.Data;
using GCS_CO.Models;
using Microsoft.EntityFrameworkCore;

namespace GCS_CO.Repos
{
    public class PostalCodesRepo : IPostalCodes
    {
        ApplicationDbContext context;

        public PostalCodesRepo(ApplicationDbContext c)
        {
            context = c;
        }
        public async Task<int> AddPostalCodeAsync(PostalCode postalCode)
        {
            context.Add(postalCode);
            return await context.SaveChangesAsync();

        }

        public async Task<PostalCode> DeletePostalCodeAsync(string? id)
        {
            var ids = id.Split('-');
            var cityName = ids[0];
            var stateAbbrev = ids[1];
            PostalCode postalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == cityName && pc.StateAbbrev == stateAbbrev);
            if(postalCode == null)
            {
                context.Remove(id);
                await context.SaveChangesAsync();
            }

            return await Task.FromResult(postalCode);
        }

        public async Task<IQueryable<PostalCode>> GetAllPostalCodesAsync()
        {
            return await Task.FromResult<IQueryable<PostalCode>>(context.PostalCodes);
        }

        public async Task<IEnumerable<string>> GetDistinctRegionAbbrevAsync()
        {
            return await context.PostalCodes
            .Select(pc => pc.RegionAbbrev)
            .Distinct()
            .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetDistinctStateAbbrevAsync()
        {
            return await context.PostalCodes
            .Select(pc => pc.StateAbbrev)
            .Distinct()
            .ToListAsync();
        }

        public async Task<PostalCode> GetPostalCodeAsync(string? id)
        {
            var ids = id.Split('-');
            var cityName = ids[0];
            var stateAbbrev = ids[1];

            return await Task.FromResult<PostalCode>(context.PostalCodes.FirstOrDefault(pc => pc.CityName == cityName && pc.StateAbbrev == stateAbbrev));
        }

        public bool PostalCodeExists(string id)
        {
            var postalCode = GetPostalCodeAsync(id);
            if (postalCode != null)
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

        public void UpdatPostalCodeAsync(PostalCode postalCode, string id)
        {
            var ids = id.Split('-');
            var cityName = ids[0];
            var stateAbbrev = ids[1];
            var pc = context.PostalCodes.FirstOrDefault(pc => pc.CityName == cityName && pc.StateAbbrev == stateAbbrev);
            pc.Code = postalCode.Code;
            pc.CityName = postalCode.CityName;
            pc.StateAbbrev = postalCode.StateAbbrev;
            pc.RegionAbbrev = postalCode.RegionAbbrev;
        }
    }
}
