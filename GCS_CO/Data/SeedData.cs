using Microsoft.AspNetCore.Identity;
using GCS_CO.Models;
using Microsoft.EntityFrameworkCore;

namespace GCS_CO.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(ApplicationDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedUsersAndRolesAsync(userManager, roleManager);
            await SeedSkillsAsync(context);
            await SeedRegionsAsync(context);
            await SeedStatesAsync(context);
            await SeedPostalCodesAsync(context);
            await SeedCitiesAsync(context);
            await SeedAddressTypesAsync(context);
            await SeedEmployeesAsync(context);


        }

        private static async Task SeedUsersAndRolesAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminRoleExists = await roleManager.RoleExistsAsync("Admin");
            if (!adminRoleExists)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var adminEmail = "admin@gcs.com";
            var adminPassword = "Abc123!";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new AppUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    NormalizedEmail = adminEmail,
                };

                await userManager.CreateAsync(adminUser, adminPassword);
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            var managerRoleExists = await roleManager.RoleExistsAsync("Manager");
            if (!managerRoleExists)
            {
                await roleManager.CreateAsync(new IdentityRole("Manager"));
            }

            var managerEmail = "jj@gcs.com";
            var managerPassword = "Abc123!";
            var managerUser = await userManager.FindByEmailAsync(managerEmail);

            if (managerUser == null)
            {
                managerUser = new AppUser
                {
                    UserName = managerEmail,
                    Email = managerEmail,
                    EmailConfirmed = true,
                    FirstName = "JJ",
                    NormalizedEmail = managerEmail,
                };

                await userManager.CreateAsync(managerUser, managerPassword);
                await userManager.AddToRoleAsync(managerUser, "Manager");
            }

            var teamMemberRoleExists = await roleManager.RoleExistsAsync("Team Member");
            if (!teamMemberRoleExists)
            {
                await roleManager.CreateAsync(new IdentityRole("Team Member"));
            }

            var teamMemberEmail = "tommokky@gcs.com";
            var teamMemberPassword = "Abc123!";
            var teamMemberUser = await userManager.FindByEmailAsync(teamMemberEmail);

            if (teamMemberUser == null)
            {
                teamMemberUser = new AppUser
                {
                    UserName = teamMemberEmail,
                    Email = teamMemberEmail,
                    EmailConfirmed = true,
                    FirstName = "Tom",
                    NormalizedEmail = teamMemberEmail,
                };

                await userManager.CreateAsync(teamMemberUser, teamMemberPassword);
                await userManager.AddToRoleAsync(teamMemberUser, "Team Member");
            }
        }

        private static async Task SeedSkillsAsync(ApplicationDbContext context)
        {
            if (context.Skills.Any())
            {
                return;
            }

            var skills = new List<Skill>
            {
                new Skill { SkillName = "Data Entry 1", SkillDescription = "Data Entry 1", SkillPayRate = 50 },
                new Skill { SkillName = "Data Entry 2", SkillDescription = "Data Entry 2", SkillPayRate = 75 },
                new Skill { SkillName = "Systems Analyst 1", SkillDescription = "Systems Analyst 1", SkillPayRate = 80 },
                new Skill { SkillName = "Systems Analyst 2", SkillDescription = "Systems Analyst 2", SkillPayRate = 90 },
                new Skill { SkillName = "DB Designer 1", SkillDescription = "DB Designer 1", SkillPayRate = 90 },
                new Skill { SkillName = "DB Designer 2", SkillDescription = "DB Designer 2", SkillPayRate = 90 },
                new Skill { SkillName = "Cobol 1", SkillDescription = "Cobol 1", SkillPayRate = 120 },
                new Skill { SkillName = "Cobol 2", SkillDescription = "Cobol 2", SkillPayRate = 150 },
                new Skill { SkillName = "C++ 1", SkillDescription = "C++ 1", SkillPayRate = 90 },
                new Skill { SkillName = "C++ 2", SkillDescription = "C++ 2", SkillPayRate = 110 },
                new Skill { SkillName = "VB 1", SkillDescription = "VB 1", SkillPayRate = 100 },
                new Skill { SkillName = "VB 2", SkillDescription = "VB 2", SkillPayRate = 120 },
                new Skill { SkillName = "Cold Fusion 1", SkillDescription = "Cold Fusion 1", SkillPayRate = 120 },
                new Skill { SkillName = "Cold Fusion 2", SkillDescription = "Cold Fusion 2", SkillPayRate = 150 },
                new Skill { SkillName = "ASP 1", SkillDescription = "ASP 1", SkillPayRate = 70 },
                new Skill { SkillName = "ASP 2", SkillDescription = "ASP 2", SkillPayRate = 90 },
                new Skill { SkillName = "Oracle DBA", SkillDescription = "Oracle DBA", SkillPayRate = 150 },
                new Skill { SkillName = "SQL Server DBA", SkillDescription = "SQL Server DBA", SkillPayRate = 150 },
                new Skill { SkillName = "Network Engineer 1", SkillDescription = "Network Engineer 1", SkillPayRate = 90 },
                new Skill { SkillName = "Network Engineer 2", SkillDescription = "Network Engineer 2", SkillPayRate = 130 },
                new Skill { SkillName = "Web Administrator", SkillDescription = "Web Administrator", SkillPayRate = 50 },
                new Skill { SkillName = "Technical Writer", SkillDescription = "Technical Writer", SkillPayRate = 90 },
                new Skill { SkillName = "Project Manager", SkillDescription = "Project Manager", SkillPayRate = 180 },
            };

            await context.Skills.AddRangeAsync(skills);
            await context.SaveChangesAsync();
        }

        private static async Task SeedRegionsAsync(ApplicationDbContext context)
        {
            if (context.Regions.Any())
            {
                return;
            }

            var regions = new List<Region>
            {
                new Region { RegionName = "North", RegionAbbrev = "N" },
                new Region { RegionName = "Northwest", RegionAbbrev = "NW" },
                new Region { RegionName = "Northeast", RegionAbbrev = "NE" },
                new Region { RegionName = "South", RegionAbbrev = "S" },
                new Region { RegionName = "Southwest", RegionAbbrev = "SW" },
                new Region { RegionName = "Southeast", RegionAbbrev = "SE" },
                new Region { RegionName = "West", RegionAbbrev = "W" },
                new Region { RegionName = "Midwest", RegionAbbrev = "MW" },
                new Region { RegionName = "East", RegionAbbrev = "E" },
            };

            await context.Regions.AddRangeAsync(regions);
            await context.SaveChangesAsync();
        }

        private static async Task SeedStatesAsync(ApplicationDbContext context)
        {
            if (context.States.Any())
            {
                return;
            }

            var south = context.Regions.Single(r => r.RegionAbbrev == "S");
            var southWest = context.Regions.Single(r => r.RegionAbbrev == "SW");
            var southEast = context.Regions.Single(r => r.RegionAbbrev == "SE");
            var north = context.Regions.Single(r => r.RegionAbbrev == "N");
            var northEast = context.Regions.Single(r => r.RegionAbbrev == "NE");
            var northWest = context.Regions.Single(r => r.RegionAbbrev == "NW");
            var east = context.Regions.Single(r => r.RegionAbbrev == "E");
            var west = context.Regions.Single(r => r.RegionAbbrev == "W");
            var midWest = context.Regions.Single(r => r.RegionAbbrev == "MW");


            var states = new List<State>
            {

                new State { Region = south, StateName = "Alabama", StateAbbrev = "AL", RegionAbbrev = south.RegionAbbrev },
                new State { Region = northWest, StateName = "Alaska", StateAbbrev = "AK", RegionAbbrev = northWest.RegionAbbrev },
                new State { Region = southWest, StateName = "Arizona", StateAbbrev = "AZ", RegionAbbrev = southWest.RegionAbbrev },
                new State { Region = south, StateName = "Arkansas", StateAbbrev = "AR", RegionAbbrev = south.RegionAbbrev },
                new State { Region = west, StateName = "California", StateAbbrev = "CA", RegionAbbrev = west.RegionAbbrev },
                new State { Region = midWest, StateName = "Colorado", StateAbbrev = "CO", RegionAbbrev = midWest.RegionAbbrev },
                new State { Region = northEast, StateName = "Connecticut", StateAbbrev = "CT", RegionAbbrev = northEast.RegionAbbrev },
                new State { Region = northEast, StateName = "Delaware", StateAbbrev = "DE", RegionAbbrev = northEast.RegionAbbrev },
                new State { Region = southEast, StateName = "Florida", StateAbbrev = "FL", RegionAbbrev = southEast.RegionAbbrev },
                new State { Region = southEast, StateName = "Georgia", StateAbbrev = "GA", RegionAbbrev = southEast.RegionAbbrev },
                new State { Region = west, StateName = "Hawaii", StateAbbrev = "HI", RegionAbbrev = west.RegionAbbrev },
                new State { Region = northWest, StateName = "Idaho", StateAbbrev = "ID", RegionAbbrev = northWest.RegionAbbrev },
                new State { Region = midWest, StateName = "Illinois", StateAbbrev = "IL", RegionAbbrev = midWest.RegionAbbrev },
                new State { Region = midWest, StateName = "Indiana", StateAbbrev = "IN", RegionAbbrev = midWest.RegionAbbrev },
                new State { Region = midWest, StateName = "Iowa", StateAbbrev = "IA", RegionAbbrev = midWest.RegionAbbrev },
                new State { Region = midWest, StateName = "Kansas", StateAbbrev = "KS", RegionAbbrev = midWest.RegionAbbrev },
                new State { Region = south, StateName = "Kentucky", StateAbbrev = "KY", RegionAbbrev = south.RegionAbbrev },
                new State { Region = south, StateName = "Louisiana", StateAbbrev = "LA", RegionAbbrev = south.RegionAbbrev },
                new State { Region = northEast, StateName = "Maine", StateAbbrev = "ME", RegionAbbrev = northEast.RegionAbbrev },
                new State { Region = northEast, StateName = "Maryland", StateAbbrev = "MD", RegionAbbrev = northEast.RegionAbbrev },
                new State { Region = northEast, StateName = "Massachusetts", StateAbbrev = "MA", RegionAbbrev = northEast.RegionAbbrev },
                new State { Region = midWest, StateName = "Michigan", StateAbbrev = "MI", RegionAbbrev = midWest.RegionAbbrev },
                new State { Region = midWest, StateName = "Minnesota", StateAbbrev = "MN", RegionAbbrev = midWest.RegionAbbrev },
                new State { Region = south, StateName = "Mississippi", StateAbbrev = "MS", RegionAbbrev = south.RegionAbbrev },
                new State { Region = midWest, StateName = "Missouri", StateAbbrev = "MO", RegionAbbrev = midWest.RegionAbbrev },
                new State { Region = northWest, StateName = "Montana", StateAbbrev = "MT", RegionAbbrev = northWest.RegionAbbrev },
                new State { Region = midWest, StateName = "Nebraska", StateAbbrev = "NE", RegionAbbrev = midWest.RegionAbbrev },
                new State { Region = west, StateName = "Nevada", StateAbbrev = "NV", RegionAbbrev = west.RegionAbbrev },
                new State { Region = northEast, StateName = "New Hampshire", StateAbbrev = "NH", RegionAbbrev = northEast.RegionAbbrev },
                new State { Region = northEast, StateName = "New Jersey", StateAbbrev = "NJ", RegionAbbrev = northEast.RegionAbbrev },
                new State { Region = southWest, StateName = "New Mexico", StateAbbrev = "NM", RegionAbbrev = southWest.RegionAbbrev },
                new State { Region = northEast, StateName = "New York", StateAbbrev = "NY", RegionAbbrev = northEast.RegionAbbrev },
                new State { Region = southEast, StateName = "North Carolina", StateAbbrev = "NC", RegionAbbrev = southEast.RegionAbbrev },
                new State { Region = midWest, StateName = "North Dakota", StateAbbrev = "ND", RegionAbbrev = midWest.RegionAbbrev },
                new State { Region = midWest, StateName = "Ohio", StateAbbrev = "OH", RegionAbbrev = midWest.RegionAbbrev },
                new State { Region = south, StateName = "Oklahoma", StateAbbrev = "OK", RegionAbbrev = south.RegionAbbrev },
                new State { Region = west, StateName = "Oregon", StateAbbrev = "OR", RegionAbbrev = west.RegionAbbrev },
                new State { Region = northEast, StateName = "Pennsylvania", StateAbbrev = "PA", RegionAbbrev = northEast.RegionAbbrev },
                new State { Region = northEast, StateName = "Rhode Island", StateAbbrev = "RI", RegionAbbrev = northEast.RegionAbbrev },
                new State { Region = southEast, StateName = "South Carolina", StateAbbrev = "SC", RegionAbbrev = southEast.RegionAbbrev },
                new State { Region = midWest, StateName = "South Dakota", StateAbbrev = "SD", RegionAbbrev = midWest.RegionAbbrev },
                new State { Region = south, StateName = "Tennessee", StateAbbrev = "TN", RegionAbbrev = south.RegionAbbrev },
                new State { Region = south, StateName = "Texas", StateAbbrev = "TX", RegionAbbrev = south.RegionAbbrev },
                new State { Region = midWest, StateName = "Utah", StateAbbrev = "UT", RegionAbbrev = midWest.RegionAbbrev },
                new State { Region = northEast, StateName = "Vermont", StateAbbrev = "VT", RegionAbbrev = northEast.RegionAbbrev },
                new State { Region = south, StateName = "Virginia", StateAbbrev = "VA", RegionAbbrev = south.RegionAbbrev },
                new State { Region = northWest, StateName = "Washington", StateAbbrev = "WA", RegionAbbrev = northWest.RegionAbbrev },
                new State { Region = south, StateName = "West Virginia", StateAbbrev = "WV", RegionAbbrev = south.RegionAbbrev },
                new State { Region = midWest, StateName = "Wisconsin", StateAbbrev = "WI", RegionAbbrev = midWest.RegionAbbrev },
                new State { Region = west, StateName = "Wyoming", StateAbbrev = "WY", RegionAbbrev = west.RegionAbbrev },


            };

            await context.States.AddRangeAsync(states);
            await context.SaveChangesAsync();
        }

        private static async Task SeedPostalCodesAsync(ApplicationDbContext context)
        {
            if (context.PostalCodes.Any())
            {
                return;
            }

            var postalCodes = new List<PostalCode>
            {
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "New York"), Code = "10001", CityName = "New York City", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "New York")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "New York")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "California"), Code = "90001", CityName = "Los Angeles", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Illinois"), Code = "60601", CityName = "Chicago", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Illinois")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Illinois")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Texas"), Code = "77001", CityName = "Houston", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Arizona"), Code = "85001", CityName = "Phoenix", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Arizona")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Arizona")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Pennsylvania"), Code = "19101", CityName = "Philadelphia", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Pennsylvania")?.StateAbbrev, RegionAbbrev =  context.States.FirstOrDefault(c => c.StateName == "Pennsylvania")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Texas"), Code = "78201", CityName = "San Antonio", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "California"), Code = "92101", CityName = "San Diego", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Texas"), Code = "75201", CityName = "Dallas", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Maryland"), Code = "21201", CityName = "Baltimore", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Maryland")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Maryland")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Minnesota"), Code = "53201", CityName = "Milwaukee",StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Minnesota")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Minnesota")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "New Mexico"), Code = "87101", CityName = "Albuquerque", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "New Mexico")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "New Mexico")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Arizona"), Code = "85701", CityName = "Tucson", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Arizona")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Arizona")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "California"), Code = "93701", CityName = "Fresno", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "California"), Code = "95814", CityName = "Sacramento", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Missouri"), Code = "64101", CityName = "Kansas City", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Missouri")?.StateAbbrev, RegionAbbrev =  context.States.FirstOrDefault(c => c.StateName == "Missouri")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "California"), Code = "90801", CityName = "Long Beach", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "New Mexico"), Code = "85201", CityName = "Mesa", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "New Mexico")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "New Mexico")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Georgia"), Code = "30301", CityName = "Atlanta", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Georgia")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Georgia")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Colorado"), Code = "80901", CityName = "Colorado Springs", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Colorado")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Colorado")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "North Carolina"), Code = "27601", CityName = "Raleigh", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "North Carolina")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "North Carolina")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Florida"), Code = "33101", CityName = "Miami", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Florida")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Florida")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "California"), Code = "94601", CityName = "Oakland", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Minnesota"), Code = "55401", CityName = "Minneapolis", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Minnesota")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Minnesota")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Oklahoma"), Code = "74101", CityName = "Tulsa", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Oklahoma")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Oklahoma")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Ohio"), Code = "44101", CityName = "Cleveland", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Ohio")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Ohio")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Kansas"), Code = "67201", CityName = "Wichita", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Kansas")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Kansas")?.RegionAbbrev },
                new PostalCode { State = context.States.FirstOrDefault(s => s.StateName == "Texas"), Code = "76001", CityName = "Arlington",StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.RegionAbbrev },

            };

            await context.PostalCodes.AddRangeAsync(postalCodes);
            await context.SaveChangesAsync();
        }

        private static async Task SeedCitiesAsync(ApplicationDbContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }

            var cities = new List<City>
            {
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "New York"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "New York City" && pc.StateAbbrev == "NY"),
                CityName = "New York City",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY").Code

            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "California"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Los Angeles" && pc.StateAbbrev == "CA"),
                CityName = "Los Angeles",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Los Angeles" && c.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Los Angeles" && c.StateAbbrev == "CA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Los Angeles" && c.StateAbbrev == "CA")?.Code

            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Illinois"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Chicago" && pc.StateAbbrev == "IL"),
                CityName = "Chicago",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.Code
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Texas"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Houston" && pc.StateAbbrev == "TX"),
                CityName = "Houston",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Houston" && c.StateAbbrev == "TX")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Houston" && c.StateAbbrev == "TX")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Houston" && c.StateAbbrev == "TX")?.Code
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Arizona"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Phoenix" && pc.StateAbbrev == "AZ"),
                CityName = "Phoenix",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Phoenix" && c.StateAbbrev == "AZ")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Phoenix" && c.StateAbbrev == "AZ")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Phoenix" && c.StateAbbrev == "AZ")?.Code,
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Pennsylvania"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Philadelphia" && pc.StateAbbrev == "PA"),
                CityName = "Philadelphia",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Philadelphia" && c.StateAbbrev == "PA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Philadelphia" && c.StateAbbrev == "PA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Philadelphia" && c.StateAbbrev == "PA")?.Code
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Texas"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "San Antonio" && pc.StateAbbrev == "TX"),
                CityName = "San Antonio",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "San Antonio" && c.StateAbbrev == "TX")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "San Antonio" && c.StateAbbrev == "TX")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "San Antonio" && c.StateAbbrev == "TX")?.Code
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "California"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "San Diego" && pc.StateAbbrev == "CA"),
                CityName = "San Diego",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "San Diego" && c.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "San Diego" && c.StateAbbrev == "CA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "San Diego" && c.StateAbbrev == "CA")?.Code
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Texas"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Dallas" && pc.StateAbbrev == "TX"),
                CityName = "Dallas",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Dallas" && c.StateAbbrev == "TX")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Dallas" && c.StateAbbrev == "TX")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Dallas" && c.StateAbbrev == "TX")?.Code
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Maryland"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Baltimore" && pc.StateAbbrev == "MD"),
                CityName = "Baltimore",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Baltimore" && c.StateAbbrev == "MD")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Baltimore" && c.StateAbbrev == "MD")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Baltimore" && c.StateAbbrev == "MD")?.Code,
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Minnesota"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Milwaukee" && pc.StateAbbrev == "MN"),
                CityName = "Milwaukee",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Milwaukee" && c.StateAbbrev == "MN")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Milwaukee" && c.StateAbbrev == "MN")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Milwaukee" && c.StateAbbrev == "MN")?.Code,
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "New Mexico"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Albuquerque" && pc.StateAbbrev == "NM"),
                CityName = "Albuquerque",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Albuquerque" && c.StateAbbrev == "NM")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Albuquerque" && c.StateAbbrev == "NM")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Albuquerque" && c.StateAbbrev == "NM")?.Code,
            },

           new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Arizona"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Tuscon" && pc.StateAbbrev == "AZ"),
                CityName = "Tucson",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Tucson" && c.StateAbbrev == "AZ")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Tucson" && c.StateAbbrev == "AZ")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Tucson" && c.StateAbbrev == "AZ")?.Code,
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "California"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Fresno" && pc.StateAbbrev == "CA"),
                CityName = "Fresno",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.Code,
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "California"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Sacramento" && pc.StateAbbrev == "CA"),
                CityName = "Sacramento",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.Code,
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Missoouri"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Kansas City" && pc.StateAbbrev == "MO"),
                CityName = "Kansas City",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Kansas City" && c.StateAbbrev == "MO")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Kansas City" && c.StateAbbrev == "MO")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Kansas City" && c.StateAbbrev == "MO")?.Code,
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "California"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Long Beach" && pc.StateAbbrev == "CA"),
                CityName = "Long Beach",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Long Beach" && c.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Long Beach" && c.StateAbbrev == "CA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Long Beach" && c.StateAbbrev == "CA")?.Code,
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "New Mexico"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Mesa" && pc.StateAbbrev == "NM"),
                CityName = "Mesa",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Mesa" && c.StateAbbrev == "NM")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Mesa" && c.StateAbbrev == "NM")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Mesa" && c.StateAbbrev == "NM")?.Code,
            },

            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Georgia"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Atlanta" && pc.StateAbbrev == "GA"),
                CityName = "Atlanta",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Atlanta" && c.StateAbbrev == "GA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Atlanta" && c.StateAbbrev == "GA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Atlanta" && c.StateAbbrev == "GA")?.Code
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Colorado"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Colorado Springs" && pc.StateAbbrev == "CO"),
                CityName = "Colorado Springs",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Colorado Springs" && c.StateAbbrev == "CO")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Colorado Springs" && c.StateAbbrev == "CO")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Colorado Springs" && c.StateAbbrev == "CO")?.Code
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "North Carolina"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Releigh" && pc.StateAbbrev == "NC"),
                CityName = "Raleigh",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Raleigh" && c.StateAbbrev == "NC")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Raleigh" && c.StateAbbrev == "NC")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Raleigh" && c.StateAbbrev == "NC")?.Code
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Miami"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Miami" && pc.StateAbbrev == "FL"),
                CityName = "Miami",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Miami" && c.StateAbbrev == "FL")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Miami" && c.StateAbbrev == "FL")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Miami" && c.StateAbbrev == "FL")?.Code
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "California"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Oakland" && pc.StateAbbrev == "CA"),
                CityName = "Oakland",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Oakland" && c.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Oakland" && c.StateAbbrev == "CA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Oakland" && c.StateAbbrev == "CA")?.Code
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Minnesota"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Minneapolis" && pc.StateAbbrev == "MN"),
                CityName = "Minneapolis",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Minneapolis" && c.StateAbbrev == "MN")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Minneapolis" && c.StateAbbrev == "MN")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Minneapolis" && c.StateAbbrev == "MN")?.Code,
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Oaklahoma"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Tulsa" && pc.StateAbbrev == "OK"),
                CityName = "Tulsa",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Tulsa" && c.StateAbbrev == "OK")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Tulsa" && c.StateAbbrev == "OK")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Tulsa" && c.StateAbbrev == "OK")?.Code
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Ohio"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "CLeveland" && pc.StateAbbrev == "OH"),
                CityName = "Cleveland",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Cleveland" && c.StateAbbrev == "OH")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Cleveland" && c.StateAbbrev == "OH")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Cleveland" && c.StateAbbrev == "OH")?.Code
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Kansas"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Witchita" && pc.StateAbbrev == "KS"),
                CityName = "Wichita",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Wichita" && c.StateAbbrev == "KS")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Wichita" && c.StateAbbrev == "KS")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Wichita" && c.StateAbbrev == "KS")?.Code
            },
            new City
            {
                State = context.States.FirstOrDefault(s => s.StateName == "Texas"),
                PostalCode = context.PostalCodes.FirstOrDefault(pc => pc.CityName == "Alington" && pc.StateAbbrev == "TX"),
                CityName = "Arlington",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Arlington" && c.StateAbbrev == "TX")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Arlington" && c.StateAbbrev == "TX")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Arlington" && c.StateAbbrev == "TX")?.Code
            },

        };

            await context.Cities.AddRangeAsync(cities);
            await context.SaveChangesAsync();
        }

        private static async Task SeedAddressTypesAsync(ApplicationDbContext context)
        {
            if (context.AddressTypes.Any())
            {
                return;
            }
            var addressTypes = new List<AddressType>
            {
                new AddressType
                {
                    Type = "Home",
                },

                new AddressType
                {
                    Type = "Office",
                },

                new AddressType
                {
                    Type = "Mailing",
                },

                new AddressType
                {
                    Type = "PO Box",
                },
            };

            await context.AddressTypes.AddRangeAsync(addressTypes);
            await context.SaveChangesAsync();
        }

        private static async Task SeedEmployeesAsync(ApplicationDbContext context)
        {
            if (context.Employees.Any())
            {
                return;
            }

            var employees = new List<Employee>
            {

                new Employee
                {
                    FirstName = "Shawna",
                    LastName = "Staff",
                    Email = "staffs@gcs.com",
                    PhoneNumber = "9163348986",
                    DateHired = new DateTime(2023, 1, 1),
                    RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "California").RegionAbbrev,
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            Street = "8969 Rosetta Circle",
                            CityName = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.CityName,
                            PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.Code,
                            StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.StateAbbrev,
                            RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.RegionAbbrev,
                            Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                            City = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")
                        }
                    },
                    EmployeeSkills = new List<EmployeeSkill>
                    {
                        new EmployeeSkill
                        {
                            Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Shawna" && e.LastName == "Staff" && e.Email == "staffs@gcs.com"),
                            Skill = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 1"),
                            SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 1").SkillName,
                            SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 1").SkillDescription,
                            SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 1").SkillPayRate,
                            FirstName = "Shawna",
                            LastName = "Staff",

                        }
                    },
                },
                  new Employee
                  {
                       FirstName = "Amy",
                       LastName = "Seaton",
                       Email = "seatona@gcs.com",
                       PhoneNumber = "9163389091",
                       DateHired = new DateTime(2023, 1, 1),
                       RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "California").RegionAbbrev,
                       Addresses = new List<Address>
                       {
                            new Address
                            {
                                Street = "123 Elm Street",
                                CityName = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.CityName,
                                PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.Code,
                                StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.StateAbbrev,
                                RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.RegionAbbrev,
                                Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                            }
                        },
                        EmployeeSkills = new List<EmployeeSkill>
                        {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Amy" && e.LastName == "Seaton" && e.Email == "seatona@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 2").SkillPayRate,
                                FirstName = "Amy",
                                LastName = "Seaton",

                            },
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Amy" && e.LastName == "Seaton" && e.Email == "seatona@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 1").SkillPayRate,
                                FirstName = "Amy",
                                LastName = "Seaton",

                            }
                        },
                  },
                  new Employee
                  {
                        FirstName = "William",
                        LastName = "Josh",
                        Email = "joshw@gcs.com",
                        PhoneNumber = "5032098773",
                        DateHired = new DateTime(2023, 1, 1),
                        RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "California").RegionAbbrev,
                        Addresses = new List<Address>
                        {
                            new Address
                            {
                                Street = "8974 Trovita Way",
                                CityName = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.CityName,
                                PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.Code,
                                StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.StateAbbrev,
                                RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.RegionAbbrev,
                                Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                            }
                        },
                        EmployeeSkills = new List<EmployeeSkill>
                        {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "William" && e.LastName == "Josh" && e.Email == "joshw@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 2").SkillPayRate,
                                FirstName = "William",
                                LastName = "Josh",

                            },
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "William" && e.LastName == "Josh" && e.Email == "joshw@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 1").SkillPayRate,
                                FirstName = "William",
                                LastName = "Josh",

                            }
                        },
                  },
                  new Employee
                  {
                        FirstName = "Trish",
                        LastName = "Underwood",
                        Email = "underwoodt@gcs.com",
                        PhoneNumber = "2083625576",
                        DateHired = new DateTime(2023, 1, 1),
                        RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "New York").RegionAbbrev,
                        Addresses = new List<Address>
                        {
                            new Address
                            {
                                Street = "PO Box 145",
                                CityName = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.CityName,
                                PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.Code,
                                StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.StateAbbrev,
                                RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.RegionAbbrev,
                                Type = context.AddressTypes.FirstOrDefault(a => a.Type == "PO Box")?.Type,
                            }
                        },
                        EmployeeSkills = new List<EmployeeSkill>
                        {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Trish" && e.LastName == "Underwood" && e.Email == "underwodt@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "DATA ENTRY 1").SkillPayRate,
                                FirstName = "Trish",
                                LastName = "Underwood",

                            }
                        },
                  },
                  new Employee
                  {
                        FirstName = "Brett",
                        LastName = "Craig",
                        Email = "craigb@gcs.com",
                        PhoneNumber = "2087675634",
                        DateHired = new DateTime(2023, 1, 1),
                        RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "New York").RegionAbbrev,
                        Addresses = new List<Address>
                        {
                            new Address
                            {
                                Street = "715 112th Street #56",
                                CityName = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.CityName,
                                PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.Code,
                                StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.StateAbbrev,
                                RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.RegionAbbrev,
                                Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Mailing")?.Type,
                            }
                        },
                        EmployeeSkills = new List<EmployeeSkill>
                        {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Brett" && e.LastName == "Craig" && e.Email == "craigb@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1").SkillPayRate,
                                FirstName = "Brett",
                                LastName = "Craig",

                            }
                        },
                  },
                    new Employee
                    {
                        FirstName = "Beth",
                        LastName = "Sewel",
                        Email = "sewelb@gcs.com",
                        PhoneNumber = "7889876767",
                        DateHired = new DateTime(2023, 1, 1),
                        RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "Texas").RegionAbbrev,
                        Addresses = new List<Address>
                        {
                            new Address
                            {
                                Street = "2897 Jasper Lane",
                                CityName = context.Cities.FirstOrDefault(c => c.CityName == "Arlington" && c.StateAbbrev == "TX")?.CityName,
                                PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Arlington" && c.StateAbbrev == "TX")?.Code,
                                StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Arlington" && c.StateAbbrev == "TX")?.StateAbbrev,
                                RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Arlington" && c.StateAbbrev == "TX")?.RegionAbbrev,
                                Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                            }
                        },
                        EmployeeSkills = new List<EmployeeSkill>
                        {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Beth" && e.LastName == "Sewel" && e.Email == "sewelb@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1").SkillPayRate,
                                FirstName = "Beth",
                                LastName = "Sewel",

                            }
                        },
                    },
                    new Employee
                    {
                        FirstName = "Erin",
                        LastName = "Robbins",
                        Email = "robbinse@gcs.com",
                        PhoneNumber = "3985667633",
                        DateHired = new DateTime(2023, 1, 1),
                        RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "Texas").RegionAbbrev,
                        Addresses = new List<Address>
                        {
                            new Address
                            {
                                Street = "3411 Jinx Street",
                                CityName = context.Cities.FirstOrDefault(c => c.CityName == "Arlington" && c.StateAbbrev == "TX")?.CityName,
                                PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Arlington" && c.StateAbbrev == "TX")?.Code,
                                StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Arlington" && c.StateAbbrev == "TX")?.StateAbbrev,
                                RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Arlington" && c.StateAbbrev == "TX")?.RegionAbbrev,
                                Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                            }
                        },
                        EmployeeSkills = new List<EmployeeSkill>
                        {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Erin" && e.LastName == "Robbins" && e.Email == "robbinse@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1").SkillPayRate,
                                FirstName = "Erin",
                                LastName = "Robbins",

                            },
                             new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Erin" && e.LastName == "Robbins" && e.Email == "robbinse@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 2").SkillPayRate,
                                FirstName = "Erin",
                                LastName = "Robbins",

                            }
                        },
                    },
                    new Employee
                    {
                        FirstName = "Emily",
                        LastName = "Bush",
                        Email = "bushe@gcs.com",
                        PhoneNumber = "3216728798",
                        DateHired = new DateTime(2023, 1, 1),
                        RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "Texas").RegionAbbrev,
                        Addresses = new List<Address>
                        {
                            new Address
                            {
                                Street = "543 E Street Unit 12",
                                CityName = context.Cities.FirstOrDefault(c => c.CityName == "Arlington" && c.StateAbbrev == "TX")?.CityName,
                                PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Arlington" && c.StateAbbrev == "TX")?.Code,
                                StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Arlington" && c.StateAbbrev == "TX")?.StateAbbrev,
                                RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Arlington" && c.StateAbbrev == "TX")?.RegionAbbrev,
                                Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                            }
                        },
                        EmployeeSkills = new List<EmployeeSkill>
                        {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Emily" && e.LastName == "Bush" && e.Email == "bushe@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1").SkillPayRate,
                                FirstName = "Emily",
                                LastName = "Bush",

                            },
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Emily" && e.LastName == "Bush" && e.Email == "bushe@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 1").SkillPayRate,
                                FirstName = "Emily",
                                LastName = "Bush",

                            },
                             new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Emily" && e.LastName == "Bush" && e.Email == "bushe@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 2").SkillPayRate,
                                FirstName = "Emily",
                                LastName = "Bush",

                            },
                             new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Emily" && e.LastName == "Bush" && e.Email == "bushe@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 1").SkillPayRate,
                                FirstName = "Emily",
                                LastName = "Bush",

                            },
                             new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Emily" && e.LastName == "Bush" && e.Email == "bushe@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 1").SkillPayRate,
                                FirstName = "Emily",
                                LastName = "Bush",

                            },
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Emily" && e.LastName == "Bush" && e.Email == "bushe@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 2").SkillPayRate,
                                FirstName = "Emily",
                                LastName = "Bush",
                            },
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Emily" && e.LastName == "Bush" && e.Email == "bushe@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "WEB ADMINISTRATOR"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "WEB ADMINISTRATOR").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "WEB ADMINISTRATOR").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "WEB ADMINISTRATOR").SkillPayRate,
                                FirstName = "Emily",
                                LastName = "Bush",

                            }
                        },
                    },
                    new Employee
                    {
                        FirstName = "Steve",
                        LastName = "Zebras",
                        Email = "zebrass@gcs.com",
                        PhoneNumber = "5647882394",
                        DateHired = new DateTime(2023, 1, 1),
                        RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "Illinois").RegionAbbrev,
                        Addresses = new List<Address>
                        {
                            new Address
                            {
                                Street = "658 Tower Avenue",
                                CityName = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.CityName,
                                PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.Code,
                                StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.StateAbbrev,
                                RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.RegionAbbrev,
                                Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                            }
                        },
                        EmployeeSkills = new List<EmployeeSkill>
                        {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Steve" && e.LastName == "Zebras" && e.Email == "zebrass@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 1").SkillPayRate,
                                FirstName = "Steve",
                                LastName = "Zebras",

                            },
                             new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Steve" && e.LastName == "Zebras" && e.Email == "zebrass@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "VB 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "VB 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "VB 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "VB 1").SkillPayRate,
                                FirstName = "Steve",
                                LastName = "Zebras",

                            },
                              new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Steve" && e.LastName == "Zebras" && e.Email == "zebrass@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "VB 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "VB 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "VB 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "VB 2").SkillPayRate,
                                FirstName = "Steve",
                                LastName = "Zebras",

                            },
                        },
                   },
                     new Employee
                    {
                        FirstName = "Joseph",
                        LastName = "Chandler",
                        Email = "chandlerj@gcs.com",
                        PhoneNumber = "4857896011",
                        DateHired = new DateTime(2023, 1, 1),
                        RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "Illinois").RegionAbbrev,
                        Addresses = new List<Address>
                        {
                            new Address
                            {
                                Street = "9809 Old Ranch Road",
                                CityName = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.CityName,
                                PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.Code,
                                StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.StateAbbrev,
                                RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.RegionAbbrev,
                                Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                            }
                        },
                        EmployeeSkills = new List<EmployeeSkill>
                        {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Joseph" && e.LastName == "Chandler" && e.Email == "chandlerj@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 2").SkillPayRate,
                                FirstName = "Joseph",
                                LastName = "Chandler",

                            },
                        },
                   },
                      new Employee
                      {
                        FirstName = "Shane",
                        LastName = "Burklow",
                        Email = "burklows@gcs.com",
                        PhoneNumber = "4857896011",
                        DateHired = new DateTime(2023, 1, 1),
                        RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "Illinois").RegionAbbrev,
                        Addresses = new List<Address>
                        {
                            new Address
                            {
                                Street = "45678 MountainView Street",
                                CityName = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.CityName,
                                PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.Code,
                                StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.StateAbbrev,
                                RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.RegionAbbrev,
                                Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                            }
                        },
                        EmployeeSkills = new List<EmployeeSkill>
                        {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Shane" && e.LastName == "Burklow" && e.Email == "burklows@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "SYSTEMS ANALYST 2").SkillPayRate,
                                FirstName = "Shane",
                                LastName = "Burklow",

                            },
                        },
                      },
                      new Employee
                      {
                            FirstName = "Peter",
                            LastName = "Yarbrough",
                            Email = "yarbroughp@gcs.com",
                            PhoneNumber = "4857896011",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "Illinois").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "123 Eclaire Road",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Peter" && e.LastName == "Yarbrough" && e.Email == "yarbroughp@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 1").SkillPayRate,
                                FirstName = "Peter",
                                LastName = "Yarbrough",

                            },
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Peter" && e.LastName == "Yarbrough" && e.Email == "yarbroughp@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 2").SkillPayRate,
                                FirstName = "Peter",
                                LastName = "Yarbrough",

                            },
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Peter" && e.LastName == "Yarbrough" && e.Email == "yarbroughp@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "SQL SERVER DBA"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "SQL SERVER DBA").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "SQL SERVER DBA").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "SQL SERVER DBA").SkillPayRate,
                                FirstName = "Peter",
                                LastName = "Yarbrough",

                            },
                      },
                   },
                      new Employee
                      {
                            FirstName = "Mary",
                            LastName = "Smith",
                            Email = "smithm@gcs.com",
                            PhoneNumber = "5887665665",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "Illinois").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "555 Alder Street",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Mary" && e.LastName == "Smith" && e.Email == "smithm@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 1").SkillPayRate,
                                FirstName = "Mary",
                                LastName = "Smith",

                            },
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Mary" && e.LastName == "Smith" && e.Email == "smithm@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 1").SkillPayRate,
                                FirstName = "Mary",
                                LastName = "Smith",
                            },
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Mary" && e.LastName == "Smith" && e.Email == "smithm@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "NETWORK ENGINEER 2").SkillPayRate,
                                FirstName = "Mary",
                                LastName = "Smith",
                            },
                              new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Mary" && e.LastName == "Smith" && e.Email == "smithm@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "WEB ADMINISTRATOR"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "WEB ADMINISTRATOR").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "WEB ADMINISTRATOR").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "WEB ADMINISTRATOR").SkillPayRate,
                                FirstName = "Mary",
                                LastName = "Smith",
                            },
                      },
                   },
                      new Employee
                      {
                            FirstName = "Johnathon",
                            LastName = "Pascoe",
                            Email = "pascoej@gcs.com",
                            PhoneNumber = "5887665665",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "Illinois").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "PO Box 12",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "PO Box")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Johnathon" && e.LastName == "Pascoe" && e.Email == "pascoej@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "DB DESIGNER 2").SkillPayRate,
                                FirstName = "Johnathon",
                                LastName = "Pascoe",

                            },
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Johnathon" && e.LastName == "Pascoe" && e.Email == "pascoej@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "ORACLE DBA"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "ORACLE DBA").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "ORACLE DBA").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "ORACLE DBA").SkillPayRate,
                                FirstName = "Johnathon",
                                LastName = "Pascoe",
                            },
                      },
                   },
                      new Employee
                      {
                            FirstName = "Chris",
                            LastName = "Kattan",
                            Email = "pascoej@gcs.com",
                            PhoneNumber = "9075654432",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "Illinois").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "87 5Th Avenue #288",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Chris" && e.LastName == "Kattan" && e.Email == "kattanc@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1").SkillPayRate,
                                FirstName = "Chris",
                                LastName = "Kattan",

                            },
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Chris" && e.LastName == "Kattan" && e.Email == "kattanc@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 2").SkillPayRate,
                                FirstName = "Chris",
                                LastName = "Kattan",
                            },
                      },
                   },
                      new Employee
                      {
                            FirstName = "Victor",
                            LastName = "Ephanor",
                            Email = "ephanorv@gcs.com",
                            PhoneNumber = "6878774434",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "Illinois").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "2398 Fulton Avenue",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Victor" && e.LastName == "Ephanor" && e.Email == "ephanorv@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1").SkillPayRate,
                                FirstName = "Victor",
                                LastName = "Ephanor",

                            },
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Victor" && e.LastName == "Ephanor" && e.Email == "ephanorv@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 2").SkillPayRate,
                                FirstName = "Victor",
                                LastName = "Ephanor",
                            },
                      },
                   },
                      new Employee
                      {
                            FirstName = "Anna",
                            LastName = "Summers",
                            Email = "summersa@gcs.com",
                            PhoneNumber = "3327282432",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "Illinois").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "7767 Cristal Lane",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Anna" && e.LastName == "Summers" && e.Email == "summersa@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1").SkillPayRate,
                                FirstName = "Anna",
                                LastName = "Summers",

                            },
                      },
                   },
                      new Employee
                      {
                            FirstName = "Maria",
                            LastName = "Ellis",
                            Email = "ellism@gcs.com",
                            PhoneNumber = "6223476584",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "California").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "12877 Wimding Way",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Maria" && e.LastName == "Ellis" && e.Email == "ellism@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 1").SkillPayRate,
                                FirstName = "Maria",
                                LastName = "Ellis",

                            },
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Maria" && e.LastName == "Ellis" && e.Email == "ellism@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "VB 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "VB 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "VB 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "VB 1").SkillPayRate,
                                FirstName = "Maria",
                                LastName = "Ellis",

                            },
                      },
                   },
                      new Employee
                      {
                            FirstName = "Melissa",
                            LastName = "Batts",
                            Email = "battsm@gcs.com",
                            PhoneNumber = "9165052345",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "California").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "2345 Trajan Drive",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Melissa" && e.LastName == "Batts" && e.Email == "battsm@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "COBOL 2").SkillPayRate,
                                FirstName = "Melissa",
                                LastName = "Batts",

                            },
                      },
                   },

                      new Employee
                      {
                            FirstName = "Jose",
                            LastName = "Smith",
                            Email = "smithj@gcs.com",
                            PhoneNumber = "5036782022",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "California").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "2345 Carmicheal Way",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Jose" && e.LastName == "Smith" && e.Email == "smithj@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 1").SkillPayRate,
                                FirstName = "Jose",
                                LastName = "Smith",
                            },
                      },
                   },

                      new Employee
                      {
                            FirstName = "Adam",
                            LastName = "Rogers",
                            Email = "rogersa@gcs.com",
                            PhoneNumber = "2134334423",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "California").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "2345 Trajan",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Adam" && e.LastName == "Rogers" && e.Email == "rogersa@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 1").SkillPayRate,
                                FirstName = "Adam",
                                LastName = "Rogers",
                            },
                      },
                   },
                       new Employee
                      {
                            FirstName = "Leslie",
                            LastName = "Cope",
                            Email = "copel@gcs.com",
                            PhoneNumber = "61123278733",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "California").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "12134 White Rock Road",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Leslie" && e.LastName == "Cope" && e.Email == "copel@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 1").SkillPayRate,
                                FirstName = "Leslie",
                                LastName = "Cope",
                            },
                      },
                   },
                        new Employee
                      {
                            FirstName = "Bible",
                            LastName = "Hannah",
                            Email = "hannahb@gcs.com",
                            PhoneNumber = "5434346777",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "California").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "347 Auburn Boulevard",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Bible" && e.LastName == "Hannah" && e.Email == "hannahb@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "C++ 2").SkillPayRate,
                                FirstName = "Bible",
                                LastName = "Hannah",
                            },
                        },
                   },
                      new Employee
                      {
                            FirstName = "Christopher",
                            LastName = "Newton",
                            Email = "newtonc@gcs.com",
                            PhoneNumber = "2134334423",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "California").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "4355 Canberra Drive",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Christopher" && e.LastName == "Newton" && e.Email == "newtonc@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "VB 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "VB 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "VB 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "VB 2").SkillPayRate,
                                FirstName = "Christopher",
                                LastName = "Newton",
                            },
                             new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Christopher" && e.LastName == "Newton" && e.Email == "newtonc@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 2").SkillPayRate,
                                FirstName = "Christopher",
                                LastName = "Newton",
                            },
                              new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Christopher" && e.LastName == "Newton" && e.Email == "newtonc@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 2").SkillPayRate,
                                FirstName = "Christopher",
                                LastName = "Newton",
                            },
                                new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Christopher" && e.LastName == "Newton" && e.Email == "newtonc@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "WEB ADMINISTRATOR"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "WEB ADMINISTRATOR").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "WEB ADMINISTRATOR").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "WEB ADMINISTRATOR").SkillPayRate,
                                FirstName = "Christopher",
                                LastName = "Newton",
                            },
                      },
                   },
                      new Employee
                      {
                            FirstName = "Miriam",
                            LastName = "Duarte",
                            Email = "duartem@gcs.com",
                            PhoneNumber = "9447621198",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "California").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "3477 Folsom Drive",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Miriam" && e.LastName == "Duarte" && e.Email == "duartem@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "COLD FUSION 1").SkillPayRate,
                                FirstName = "Miriam",
                                LastName = "Duarte",
                            },
                             new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Miriam" && e.LastName == "Duarte" && e.Email == "duartem@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 1"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 1").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 1").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 1").SkillPayRate,
                                FirstName = "Miriam",
                                LastName = "Duarte",
                            },
                              new EmployeeSkill
                            {
                              Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Miriam" && e.LastName == "Duarte" && e.Email == "duartem@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 2"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 2").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 2").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "ASP 2").SkillPayRate,
                                FirstName = "Miriam",
                                LastName = "Duarte",
                            },
                      },
                   },
                       new Employee
                      {
                            FirstName = "Kilby",
                            LastName = "Surgina",
                            Email = "surginak@gcs.com",
                            PhoneNumber = "9447621198",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "New York").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "576 116th Avenue",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Kilby" && e.LastName == "Surgina" && e.Email == "surginak@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "TECHNICAL WRITER"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "TECHNICAL WRITER").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "TECHNICAL WRITER").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "TECHNICAL WRITER").SkillPayRate,
                                FirstName = "Kilby",
                                LastName = "Surgina",
                            },
                      },
                   },
                       new Employee
                      {
                            FirstName = "Larry",
                            LastName = "Bender",
                            Email = "benderl@gcs.com",
                            PhoneNumber = "7616652345",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "New York").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "777 125TH Avenue",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Larry" && e.LastName == "Bender" && e.Email == "benderl@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "TECHNICAL WRITER"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "TECHNICAL WRITER").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "TECHNICAL WRITER").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "TECHNICAL WRITER").SkillPayRate,
                                FirstName = "Larry",
                                LastName = "Bender",
                            },
                      },
                   },
                      new Employee
                      {
                            FirstName = "Brad",
                            LastName = "Paine",
                            Email = "paineb@gcs.com",
                            PhoneNumber = "5907865645",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "New York").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "6543 Oak Way",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Brad" && e.LastName == "Paine" && e.Email == "paineb@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER").SkillPayRate,
                                FirstName = "Brad",
                                LastName = "Paine",
                            },
                      },
                   },

                      new Employee
                      {
                            FirstName = "Roger",
                            LastName = "Mudd",
                            Email = "muddr@gcs.com",
                            PhoneNumber = "7765548787",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "California").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "5567 View Way",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Roger" && e.LastName == "Mudd" && e.Email == "muddr@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER").SkillPayRate,
                                FirstName = "Roger",
                                LastName = "Mudd",
                            },
                      },
                   },
                      new Employee
                      {
                            FirstName = "Tiffany",
                            LastName = "Kinyan",
                            Email = "kinyant@gcs.com",
                            PhoneNumber = "2123234567",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "California").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "4567 Coloma Street",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Tiffany" && e.LastName == "Kinyan" && e.Email == "kinyant@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER").SkillPayRate,
                                FirstName = "Tiffany",
                                LastName = "Kinyan",
                            },
                      },
                   },
                      new Employee
                      {
                            FirstName = "Sean",
                            LastName = "Conner",
                            Email = "conners@gcs.com",
                            PhoneNumber = "6546675645",
                            DateHired = new DateTime(2023, 1, 1),
                            RegionAbbrev = context.States.FirstOrDefault(s => s.StateName == "Illinois").RegionAbbrev,
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Street = "8867 Trifecta Avenue",
                                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.CityName,
                                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.Code,
                                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.StateAbbrev,
                                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.RegionAbbrev,
                                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,
                                }
                            },
                            EmployeeSkills = new List<EmployeeSkill>
                            {
                            new EmployeeSkill
                            {
                                Employee = context.Employees.FirstOrDefault(e => e.FirstName == "Sean" && e.LastName == "Conner" && e.Email == "conners@gcs.com"),
                                Skill = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER"),
                                SkillName = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER").SkillName,
                                SkillDescription = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER").SkillDescription,
                                SkillPayRate = context.Skills.FirstOrDefault(s => s.SkillName == "PROJECT MANAGER").SkillPayRate,
                                FirstName = "Sean",
                                LastName = "Conner",
                            },
                      },
                   },
            };

            await context.Employees.AddRangeAsync(employees);
            await context.SaveChangesAsync();
        }
    }
}

