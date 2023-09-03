using GCS_CO.Models;
using GCS_CO.Data;

namespace GCS_CO.Repos
{
    public interface IStates
    {

        public Task<IQueryable<State>> GetAllStatesAsync();
        public Task<State> GetStateAsync(int? id);
        public Task<int> AddStateAsync(State state);
        public void UpdateStateAsync(State state, int id);
        public Task<State> DeleteStateAsync(int? id);
        public Task DisassociateChildRecordsAsync(int id);
        public bool StateExists(int id);
        public Task SaveChangesAsync();

        public Task<IEnumerable<string>> GetDistinctRegionAbbrevAsync();
        Task<IEnumerable<Address>> GetAddressesForStateAsync(string stateAbbrev);
        Task<IEnumerable<PostalCode>> GetPostalCodesForStateAsync(string stateAbbrev);
    }
}
