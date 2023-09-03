using Xunit;
using GCS_CO.Repos;
using GCS_CO.Models;

namespace GCS_CO.Controllers.Admin.Tests
{
    public class StatesControllerTests
    {

        [Fact()]
        public void CreateTest()
        {
            var repo = new FakeStatesRepo();
            var controller = new StatesController(repo);

            repo.States.Add(new State()
            {
                StateId = 1,
                StateName = "California",
                StateAbbrev = "CA",
                RegionAbbrev = "W"

            });
            repo.States.Add(new State()
            {
                StateId = 2,
                StateName = "New York",
                StateAbbrev = "NY",
                RegionAbbrev = "NE"

            });
            repo.States.Add(new State()
            {
                StateId = 3,
                StateName = "Miami",
                StateAbbrev = "FL",
                RegionAbbrev = "S"

            });

            var states = repo.States.ToList();

            Assert.Equal(3, states.Count);
            Assert.Equal("California", states[0].StateName);
            Assert.Equal("NE", states[1].RegionAbbrev);
            Assert.Equal("Miami", states[2].StateName);
        }

        [Fact]
        public void GetAllStates()
        {
            var repo = new FakeStatesRepo();
            var controller = new StatesController(repo);

            repo.States.Add(new State()
            {
                StateId = 1,
                StateName = "California",
                StateAbbrev = "CA",
                RegionAbbrev = "W"

            });
            repo.States.Add(new State()
            {
                StateId = 2,
                StateName = "New York",
                StateAbbrev = "NY",
                RegionAbbrev = "NE"

            });
            repo.States.Add(new State()
            {
                StateId = 3,
                StateName = "Miami",
                StateAbbrev = "FL",
                RegionAbbrev = "S"

            });

            var states = repo.States.ToList();

            Assert.Equal(3, states.Count);
            Assert.Equal("CA", states[0].StateAbbrev);
            Assert.Equal("NY", states[1].StateAbbrev);
            Assert.Equal("FL", states[2].StateAbbrev);

        }

        [Fact]
        public void GetAState()
        {
            var repo = new FakeStatesRepo();
            var controller = new StatesController(repo);

            repo.States.Add(new State()
            {
                StateId = 1,
                StateName = "California",
                StateAbbrev = "CA",
                RegionAbbrev = "W"

            });
            repo.States.Add(new State()
            {
                StateId = 2,
                StateName = "New York",
                StateAbbrev = "NY",
                RegionAbbrev = "NE"

            });
            repo.States.Add(new State()
            {
                StateId = 3,
                StateName = "Miami",
                StateAbbrev = "FL",
                RegionAbbrev = "S"

            });

            int id = 3;
            var states = repo.States.ToList();
            var state = states.Find(s => s.StateId == id);
            Assert.Equal(3, states.Count);
            Assert.Equal("Miami", state?.StateName);
            Assert.Equal("S", state?.RegionAbbrev);
        }

        [Fact()]
        public void DeleteConfirmedTest()
        {
            var repo = new FakeStatesRepo();
            var controller = new StatesController(repo);

            repo.States.Add(new State()
            {
                StateId = 1,
                StateName = "California",
                StateAbbrev = "CA",
                RegionAbbrev = "W"

            });
            repo.States.Add(new State()
            {
                StateId = 2,
                StateName = "New York",
                StateAbbrev = "NY",
                RegionAbbrev = "NE"

            });
            repo.States.Add(new State()
            {
                StateId = 3,
                StateName = "Miami",
                StateAbbrev = "FL",
                RegionAbbrev = "S"

            });

            int id = 2;
            var states = repo.States.ToList();
            var state = states.Find(s => s.StateId == id);

            states.Remove(state);
            Assert.NotEqual(3, states.Count);
            Assert.Equal(2, states.Count);
            Assert.Equal("California", states[0].StateName);
            Assert.Equal("Miami", states[1].StateName);
        }

        [Fact]
        public void UpdateState()
        {
            var repo = new FakeStatesRepo();
            var controller = new StatesController(repo);

            repo.States.Add(new State()
            {
                StateId = 1,
                StateName = "California",
                StateAbbrev = "CA",
                RegionAbbrev = "W"

            });
            repo.States.Add(new State()
            {
                StateId = 2,
                StateName = "New York",
                StateAbbrev = "NY",
                RegionAbbrev = "NE"

            });
            repo.States.Add(new State()
            {
                StateId = 3,
                StateName = "Florida",
                StateAbbrev = "FL",
                RegionAbbrev = "S"

            });

            var states = repo.States.ToList();
            int id = 3;
            var state = states.Find(s => s.StateId == id);

            state.StateAbbrev = "FL";
            state.StateName = "Florida";
            state.RegionAbbrev = "E";

            Assert.Equal(3, states.Count);
            Assert.Equal("FL", state.StateAbbrev);
            Assert.Equal("Florida", state.StateName);
            Assert.Equal("E", state.RegionAbbrev);
        }
    }
}