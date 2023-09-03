using GCS_CO.Models;
using System.Drawing;

namespace GCS_CO.Repos
{
    public class FakeStatesRepo : IStates
    {
        private List<State> states = new List<State>();

        public List<State> States { get { return states; } }
        private List<PostalCode> postalCodes = new List<PostalCode>();

        public Task<int> AddStateAsync(State state)
        {
            int success = 0;
            if (state != null)
            {

                state.StateId = states.Count + 1;
                states.Add(state);
                success = 1;
            }

            return Task.FromResult<int>(success);
        }

        public Task<State> DeleteStateAsync(int? id)
        {
            var state = states.Find(s => s.StateId == id);
            states.Remove(state);
            return Task.FromResult<State>(state);
        }

        public Task DisassociateChildRecordsAsync(int id)
        {
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Address>> GetAddressesForStateAsync(string stateAbbrev)
        {
            var distinctRegionAbbrevs = states.Select(s => s.RegionAbbrev).Distinct();
            return (IEnumerable<Address>)await Task.FromResult(distinctRegionAbbrevs);
        }

        public Task<IQueryable<State>> GetAllStatesAsync()
        {
            return Task.FromResult(states.AsQueryable());
        }

        public Task<IEnumerable<PostalCode>> GetPostalCodesForStateAsync(string stateAbbrev)
        {
            var postalCodesForState = postalCodes.Where(pc => pc.StateAbbrev == stateAbbrev);

            return Task.FromResult(postalCodesForState);
        }

        public Task<State> GetStateAsync(int? id)
        {
            var state = states.Find(s => s.StateId == id);
            return Task.FromResult(state); 
        }

        public Task SaveChangesAsync()
        {
            return SaveChangesAsync();
        }

        public bool StateExists(int id)
        {
            var state = GetStateAsync(id);
            if (state != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateStateAsync(State state, int id)
        {
            var s = states.Find(s => s.StateId == id);
            s.StateAbbrev = state.StateAbbrev;
            s.StateName = state.StateName;
            s.RegionAbbrev = state.RegionAbbrev;
        }

        public Task<IEnumerable<string>> GetDistinctRegionAbbrevAsync()
        {
            throw new NotImplementedException();
        }
    }
}
