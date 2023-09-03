using Xunit;
using GCS_CO.Models;
using GCS_CO.Repos;


namespace GCS_CO.Controllers.Admin.Tests
{
    public class RegionsControllerTests
    {
        [Fact()]
        public void CreateTest()
        {
            var repo = new FakeRegionsRepo();
            var controller = new RegionsController(repo);

            repo.Regions.Add(new Region()
            {
               RegionId = 1,
               RegionAbbrev = "W",
               RegionName = "West",

            });
            repo.Regions.Add(new Region()
            {
                RegionId = 2,
                RegionAbbrev = "N",
                RegionName = "North",

            });
            repo.Regions.Add(new Region()
            {
                RegionId = 3,
                RegionAbbrev = "E",
                RegionName = "East",

            });

            var movies = repo.Regions.ToList();

            Assert.Equal(3, movies.Count);
            Assert.Equal("West", movies[0].RegionName);
            Assert.Equal("North", movies[1].RegionName);
            Assert.Equal("East", movies[2].RegionName);
        }

        [Fact]
        public void GetAllRegions()
        {
            var repo = new FakeRegionsRepo();
            var controller = new RegionsController(repo);

            repo.Regions.Add(new Region()
            {
                RegionId = 1,
                RegionAbbrev = "W",
                RegionName = "West",

            });
            repo.Regions.Add(new Region()
            {
                RegionId = 2,
                RegionAbbrev = "N",
                RegionName = "North",

            });
            repo.Regions.Add(new Region()
            {
                RegionId = 3,
                RegionAbbrev = "E",
                RegionName = "East",

            });

            var regions = repo.Regions.ToList();

            Assert.Equal(3, regions.Count);
            Assert.Equal("West", regions[0].RegionName);
            Assert.Equal("North", regions[1].RegionName);
            Assert.Equal("East", regions[2].RegionName);

        }

        [Fact]
        public void GetARegion()
        {
            var repo = new FakeRegionsRepo();
            var controller = new RegionsController(repo);

            repo.Regions.Add(new Region()
            {
                RegionId = 1,
                RegionAbbrev = "W",
                RegionName = "West",

            });
            repo.Regions.Add(new Region()
            {
                RegionId = 2,
                RegionAbbrev = "N",
                RegionName = "North",

            });
            repo.Regions.Add(new Region()
            {
                RegionId = 3,
                RegionAbbrev = "E",
                RegionName = "East",

            });

            int id = 3;
            var regions = repo.Regions.ToList();
            var region = regions.Find(r => r.RegionId == id);
            Assert.Equal(3, regions.Count);
            Assert.Equal("East", region?.RegionName);
            Assert.Equal("E", region?.RegionAbbrev);
        }

        [Fact()]
        public void DeleteConfirmedTest()
        {
            var repo = new FakeRegionsRepo();
            var controller = new RegionsController(repo);

            repo.Regions.Add(new Region()
            {
                RegionId = 1,
                RegionAbbrev = "W",
                RegionName = "West",

            });
            repo.Regions.Add(new Region()
            {
                RegionId = 2,
                RegionAbbrev = "N",
                RegionName = "North",

            });
            repo.Regions.Add(new Region()
            {
                RegionId = 3,
                RegionAbbrev = "E",
                RegionName = "East",

            });

            int id = 2;
            var regions = repo.Regions.ToList();
            var region = regions.Find(r => r.RegionId == id);

            regions.Remove(region);
            Assert.NotEqual(3, regions.Count);
            Assert.Equal(2, regions.Count);
            Assert.Equal("West", regions[0].RegionName);
            Assert.Equal("East", regions[1].RegionName);
        }
    }
}