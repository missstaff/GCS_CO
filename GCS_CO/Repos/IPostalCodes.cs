using GCS_CO.Models;

namespace GCS_CO.Repos
{
    public interface IPostalCodes
    {
        public Task<IQueryable<PostalCode>> GetAllPostalCodesAsync();
        public Task<PostalCode> GetPostalCodeAsync(string? id);
        public Task<int> AddPostalCodeAsync(PostalCode postalCode);
        public void UpdatPostalCodeAsync(PostalCode postalCode, string id);
        public Task<PostalCode> DeletePostalCodeAsync(string? id);
        public bool PostalCodeExists(string id);
        public Task SaveChangesAsync();
        public Task<IEnumerable<string>> GetDistinctRegionAbbrevAsync();
        public Task<IEnumerable<string>> GetDistinctStateAbbrevAsync();
    }
}
