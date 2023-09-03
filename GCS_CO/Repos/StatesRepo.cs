using GCS_CO.Models;

namespace GCS_CO.Repos
{
    using GCS_CO.Models;
    using GCS_CO.Data;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using System.Drawing;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class StatesRepo : IStates
    {
        ApplicationDbContext context;

        public StatesRepo(ApplicationDbContext c)
        {
            context = c;
        }

        public async Task<int> AddStateAsync(State state)
        {
            context.States.Add(state);
            return await context.SaveChangesAsync();
        }

        public async Task<State> DeleteStateAsync(int? id)
        {
            State state = context.States.FirstOrDefault(s => s.StateId == id);
            if (state != null)
            {
                context.States.Remove(state);
                await context.SaveChangesAsync();
            }

            return await Task.FromResult(state);
        }

        public async Task DisassociateChildRecordsAsync(int id)
        {
            var state = await GetStateAsync(id);
            if (state != null)
            {

                //Postal Codes
                var relatedPostalCodes = context.PostalCodes.Where(pc => pc.RegionAbbrev == state.RegionAbbrev);
                foreach (var postalCode in relatedPostalCodes)
                {
                    postalCode.RegionAbbrev = null;
                }

                //Cities
                var relatedCities = context.Cities.Where(c => c.RegionAbbrev == state.RegionAbbrev);
                foreach (var city in relatedCities)
                {
                    city.StateAbbrev = null;
                }

                //Addresses
                var relatedAddresses = context.Addresses.Where(a => a.RegionAbbrev == state.RegionAbbrev);
                foreach (var address in relatedAddresses)
                {
                    address.StateAbbrev = null;
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Address>> GetAddressesForStateAsync(string stateAbbrev)
        {
            var addresses = await context.Addresses
                .Where(a => a.StateAbbrev == stateAbbrev)
                .ToListAsync();

            return addresses;
        }

        public async Task<IQueryable<State>> GetAllStatesAsync()
        {
            return await Task.FromResult<IQueryable<State>>(context.States);
        }

        public async Task<IEnumerable<string>> GetDistinctRegionAbbrevAsync()
        {
            return await context.States
            .Select(state => state.RegionAbbrev)
            .Distinct()
            .ToListAsync();
        }

        public async Task<IEnumerable<PostalCode>> GetPostalCodesForStateAsync(string stateAbbrev)
        {
            var addresses = await context.PostalCodes
                .Where(a => a.StateAbbrev == stateAbbrev)
                .ToListAsync();

            return addresses;
        }

        public async Task<State> GetStateAsync(int? id)
        {
            return await Task.FromResult<State>(context.States.Find(id));
        }

        public Task SaveChangesAsync()
        {
            return context.SaveChangesAsync();
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
            var s = context.States.Find(id);
            s.StateAbbrev = state.StateAbbrev;
            s.StateName = state.StateName;
            s.RegionAbbrev = state.RegionAbbrev;
        }
    }
}
