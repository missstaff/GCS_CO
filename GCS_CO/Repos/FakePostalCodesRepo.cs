using GCS_CO.Models;

namespace GCS_CO.Repos
{
    public class FakePostalCodesRepo : IPostalCodes
    {
        private List<PostalCode> postalCodes = new List<PostalCode>();

        public List<PostalCode> PostalCodes { get { return postalCodes; } }
        public Task<int> AddPostalCodeAsync(PostalCode postalCode)
        {
            int success = 0;
            if (postalCode != null)
            {

                postalCode.CityName = "Sacramento";
                postalCode.StateAbbrev = "CA";
                postalCode.RegionAbbrev = "W";
                postalCode.Code = "95814";
                postalCodes.Add(postalCode);
                success = 1;
            }
            return Task.FromResult<int>(success);
        }

        public Task<PostalCode> DeletePostalCodeAsync(string? id)
        {
            var ids = id.Split("-");
            var cityName = ids[0];
            var stateAbbrev = ids[1];

            var postalCode = postalCodes.Find(pc => pc.CityName == cityName && pc.StateAbbrev == stateAbbrev); ;
            
            postalCodes.Remove(postalCode);
            return Task.FromResult<PostalCode>(postalCode);
        }

        public Task<IQueryable<PostalCode>> GetAllPostalCodesAsync()
        {
            return Task.FromResult(postalCodes.AsQueryable());
        }

        public Task<IEnumerable<string>> GetDistinctRegionAbbrevAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetDistinctStateAbbrevAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PostalCode> GetPostalCodeAsync(string? id)
        {
            var ids = id.Split("-");
            var cityName = ids[0];
            var stateAbbrev = ids[1];

            var postalCode = postalCodes.Find(pc => pc.CityName == cityName && pc.StateAbbrev == stateAbbrev);
            return Task.FromResult(postalCode);
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
            return SaveChangesAsync();
        }

        public void UpdatPostalCodeAsync(PostalCode postalCode, string id)
        {
            var ids = id.Split("-");
            var cityName = ids[0];
            var stateAbbrev = ids[1];

            var pc = postalCodes.Find(pc => pc.CityName == cityName && pc.StateAbbrev == stateAbbrev);

            pc.Code = postalCode.Code;
            pc.CityName = postalCode.CityName;
            pc.StateAbbrev = postalCode.StateAbbrev;
            pc.RegionAbbrev = postalCode.RegionAbbrev;
        }
    }
}
