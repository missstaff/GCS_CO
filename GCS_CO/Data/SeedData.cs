using Microsoft.AspNetCore.Identity;
using GCS_CO.Models;

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
            await SeedAddressesAsync(context);

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
                new Skill { Name = "Data Entry 1", Description = "Data Entry 1", RateOfPay = 50 },
                new Skill { Name = "Data Entry 2", Description = "Data Entry 2", RateOfPay = 75 },
                new Skill { Name = "Systems Analyst 1", Description = "Systems Analyst 1", RateOfPay = 80 },
                new Skill { Name = "Systems Analyst 2", Description = "Systems Analyst 2", RateOfPay = 90 },
                new Skill { Name = "DB Designer 1", Description = "DB Designer 1", RateOfPay = 90 },
                new Skill { Name = "DB Designer 2", Description = "DB Designer 2", RateOfPay = 90 },
                new Skill { Name = "Cobol 1", Description = "Cobol 1", RateOfPay = 120 },
                new Skill { Name = "Cobol 2", Description = "Cobol 2", RateOfPay = 150 },
                new Skill { Name = "C++ 1", Description = "C++ 1", RateOfPay = 90 },
                new Skill { Name = "C++ 2", Description = "C++ 2", RateOfPay = 110 },
                new Skill { Name = "VB 1", Description = "VB 1", RateOfPay = 100 },
                new Skill { Name = "VB 2", Description = "VB 2", RateOfPay = 120 },
                new Skill { Name = "Cold Fusion 1", Description = "Cold Fusion 1", RateOfPay = 120 },
                new Skill { Name = "Cold Fusion 2", Description = "Cold Fusion 2", RateOfPay = 150 },
                new Skill { Name = "ASP 1", Description = "ASP 1", RateOfPay = 70 },
                new Skill { Name = "ASP 2", Description = "ASP 2", RateOfPay = 90 },
                new Skill { Name = "Oracle DBA", Description = "Oracle DBA", RateOfPay = 150 },
                new Skill { Name = "SQL Server DBA", Description = "SQL Server DBA", RateOfPay = 150 },
                new Skill { Name = "Network Engineer 1", Description = "Network Engineer 1", RateOfPay = 90 },
                new Skill { Name = "Network Engineer 2", Description = "Network Engineer 2", RateOfPay = 130 },
                new Skill { Name = "Web Administrator", Description = "Web Administrator", RateOfPay = 50 },
                new Skill { Name = "Technical Writer", Description = "Technical Writer", RateOfPay = 90 },
                new Skill { Name = "Project Manager", Description = "Project Manager", RateOfPay = 180 },
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

                new State { StateName = "Alabama", StateAbbrev = "AL", RegionAbbrev = south.RegionAbbrev },
                new State { StateName = "Alaska", StateAbbrev = "AK", RegionAbbrev = northWest.RegionAbbrev },
                new State { StateName = "Arizona", StateAbbrev = "AZ", RegionAbbrev = southWest.RegionAbbrev },
                new State { StateName = "Arkansas", StateAbbrev = "AR", RegionAbbrev = south.RegionAbbrev },
                new State { StateName = "California", StateAbbrev = "CA", RegionAbbrev = west.RegionAbbrev },
                new State { StateName = "Colorado", StateAbbrev = "CO", RegionAbbrev = midWest.RegionAbbrev },
                new State { StateName = "Connecticut", StateAbbrev = "CT", RegionAbbrev = northEast.RegionAbbrev },
                new State { StateName = "Delaware", StateAbbrev = "DE", RegionAbbrev = northEast.RegionAbbrev },
                new State { StateName = "Florida", StateAbbrev = "FL", RegionAbbrev = southEast.RegionAbbrev },
                new State { StateName = "Georgia", StateAbbrev = "GA", RegionAbbrev = southEast.RegionAbbrev },
                new State { StateName = "Hawaii", StateAbbrev = "HI", RegionAbbrev = west.RegionAbbrev },
                new State { StateName = "Idaho", StateAbbrev = "ID", RegionAbbrev = northWest.RegionAbbrev },
                new State { StateName = "Illinois", StateAbbrev = "IL", RegionAbbrev = midWest.RegionAbbrev },
                new State { StateName = "Indiana", StateAbbrev = "IN", RegionAbbrev = midWest.RegionAbbrev },
                new State { StateName = "Iowa", StateAbbrev = "IA", RegionAbbrev = midWest.RegionAbbrev },
                new State { StateName = "Kansas", StateAbbrev = "KS", RegionAbbrev = midWest.RegionAbbrev },
                new State { StateName = "Kentucky", StateAbbrev = "KY", RegionAbbrev = south.RegionAbbrev },
                new State { StateName = "Louisiana", StateAbbrev = "LA", RegionAbbrev = south.RegionAbbrev },
                new State { StateName = "Maine", StateAbbrev = "ME", RegionAbbrev = northEast.RegionAbbrev },
                new State { StateName = "Maryland", StateAbbrev = "MD", RegionAbbrev = northEast.RegionAbbrev },
                new State { StateName = "Massachusetts", StateAbbrev = "MA", RegionAbbrev = northEast.RegionAbbrev },
                new State { StateName = "Michigan", StateAbbrev = "MI", RegionAbbrev = midWest.RegionAbbrev },
                new State { StateName = "Minnesota", StateAbbrev = "MN", RegionAbbrev = midWest.RegionAbbrev },
                new State { StateName = "Mississippi", StateAbbrev = "MS", RegionAbbrev = south.RegionAbbrev },
                new State { StateName = "Missouri", StateAbbrev = "MO", RegionAbbrev = midWest.RegionAbbrev },
                new State { StateName = "Montana", StateAbbrev = "MT", RegionAbbrev = northWest.RegionAbbrev },
                new State { StateName = "Nebraska", StateAbbrev = "NE", RegionAbbrev = midWest.RegionAbbrev },
                new State { StateName = "Nevada", StateAbbrev = "NV", RegionAbbrev = west.RegionAbbrev },
                new State { StateName = "New Hampshire", StateAbbrev = "NH", RegionAbbrev = northEast.RegionAbbrev },
                new State { StateName = "New Jersey", StateAbbrev = "NJ", RegionAbbrev = northEast.RegionAbbrev },
                new State { StateName = "New Mexico", StateAbbrev = "NM", RegionAbbrev = southWest.RegionAbbrev },
                new State { StateName = "New York", StateAbbrev = "NY", RegionAbbrev = northEast.RegionAbbrev },
                new State { StateName = "North Carolina", StateAbbrev = "NC", RegionAbbrev = southEast.RegionAbbrev },
                new State { StateName = "North Dakota", StateAbbrev = "ND", RegionAbbrev = midWest.RegionAbbrev },
                new State { StateName = "Ohio", StateAbbrev = "OH", RegionAbbrev = midWest.RegionAbbrev },
                new State { StateName = "Oklahoma", StateAbbrev = "OK", RegionAbbrev = south.RegionAbbrev },
                new State { StateName = "Oregon", StateAbbrev = "OR", RegionAbbrev = west.RegionAbbrev },
                new State { StateName = "Pennsylvania", StateAbbrev = "PA", RegionAbbrev = northEast.RegionAbbrev },
                new State { StateName = "Rhode Island", StateAbbrev = "RI", RegionAbbrev = northEast.RegionAbbrev },
                new State { StateName = "South Carolina", StateAbbrev = "SC", RegionAbbrev = southEast.RegionAbbrev },
                new State { StateName = "South Dakota", StateAbbrev = "SD", RegionAbbrev = midWest.RegionAbbrev },
                new State { StateName = "Tennessee", StateAbbrev = "TN", RegionAbbrev = south.RegionAbbrev },
                new State { StateName = "Texas", StateAbbrev = "TX", RegionAbbrev = south.RegionAbbrev },
                new State { StateName = "Utah", StateAbbrev = "UT", RegionAbbrev = midWest.RegionAbbrev },
                new State { StateName = "Vermont", StateAbbrev = "VT", RegionAbbrev = northEast.RegionAbbrev },
                new State { StateName = "Virginia", StateAbbrev = "VA", RegionAbbrev = south.RegionAbbrev },
                new State { StateName = "Washington", StateAbbrev = "WA", RegionAbbrev = northWest.RegionAbbrev },
                new State { StateName = "West Virginia", StateAbbrev = "WV", RegionAbbrev = south.RegionAbbrev },
                new State { StateName = "Wisconsin", StateAbbrev = "WI", RegionAbbrev = midWest.RegionAbbrev },
                new State { StateName = "Wyoming", StateAbbrev = "WY", RegionAbbrev = west.RegionAbbrev },


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
                new PostalCode { Code = "10001", CityName = "New York City", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "New York")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "New York")?.RegionAbbrev },
                new PostalCode { Code = "90001", CityName = "Los Angeles", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.RegionAbbrev },
                new PostalCode { Code = "60601", CityName = "Chicago", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Illinois")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Illinois")?.RegionAbbrev },
                new PostalCode { Code = "77001", CityName = "Houston", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.RegionAbbrev },
                new PostalCode { Code = "85001", CityName = "Phoenix", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Arizona")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Arizona")?.RegionAbbrev },
                new PostalCode { Code = "19101", CityName = "Philadelphia", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Pennsylvania")?.StateAbbrev, RegionAbbrev =  context.States.FirstOrDefault(c => c.StateName == "Pennsylvania")?.RegionAbbrev },
                new PostalCode { Code = "78201", CityName = "San Antonio", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.RegionAbbrev },
                new PostalCode { Code = "92101", CityName = "San Diego", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.RegionAbbrev },
                new PostalCode { Code = "75201", CityName = "Dallas", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.RegionAbbrev },
                new PostalCode { Code = "21201", CityName = "Baltimore", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Maryland")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Maryland")?.RegionAbbrev },
                new PostalCode { Code = "53201", CityName = "Milwaukee",StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Minnesota")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Minnesota")?.RegionAbbrev },
                new PostalCode { Code = "87101", CityName = "Albuquerque", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "New Mexico")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "New Mexico")?.RegionAbbrev },
                new PostalCode { Code = "85701", CityName = "Tucson", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Arizona")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Arizona")?.RegionAbbrev },
                new PostalCode { Code = "93701", CityName = "Fresno", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.RegionAbbrev },
                new PostalCode { Code = "95814", CityName = "Sacramento", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.RegionAbbrev },
                new PostalCode { Code = "64101", CityName = "Kansas City", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Missouri")?.StateAbbrev, RegionAbbrev =  context.States.FirstOrDefault(c => c.StateName == "Missouri")?.RegionAbbrev },
                new PostalCode { Code = "90801", CityName = "Long Beach", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.RegionAbbrev },
                new PostalCode { Code = "85201", CityName = "Mesa", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "New Mexico")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "New Mexico")?.RegionAbbrev },
                new PostalCode { Code = "30301", CityName = "Atlanta", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Georgia")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Georgia")?.RegionAbbrev },
                new PostalCode { Code = "80901", CityName = "Colorado Springs", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Colorado")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Colorado")?.RegionAbbrev },
                new PostalCode { Code = "27601", CityName = "Raleigh", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "North Carolina")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "North Carolina")?.RegionAbbrev },
                new PostalCode { Code = "33101", CityName = "Miami", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Florida")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Florida")?.RegionAbbrev },
                new PostalCode { Code = "94601", CityName = "Oakland", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "California")?.RegionAbbrev },
                new PostalCode { Code = "55401", CityName = "Minneapolis", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Minnesota")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Minnesota")?.RegionAbbrev },
                new PostalCode { Code = "74101", CityName = "Tulsa", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Oklahoma")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Oklahoma")?.RegionAbbrev },
                new PostalCode { Code = "44101", CityName = "Cleveland", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Ohio")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Ohio")?.RegionAbbrev },
                new PostalCode { Code = "67201", CityName = "Wichita", StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Kansas")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Kansas")?.RegionAbbrev },
                new PostalCode { Code = "76001", CityName = "Arlington",StateAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.StateAbbrev, RegionAbbrev = context.States.FirstOrDefault(c => c.StateName == "Texas")?.RegionAbbrev },

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
                CityName = "New York City",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "New York City" && c.StateAbbrev == "NY").Code

            },
            new City
            {
                CityName = "Los Angeles",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Los Angeles" && c.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Los Angeles" && c.StateAbbrev == "CA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Los Angeles" && c.StateAbbrev == "CA")?.Code

            },
            new City
            {
                CityName = "Chicago",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Chicago" && c.StateAbbrev == "IL")?.Code
            },
            new City
            {
                CityName = "Houston",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Houston" && c.StateAbbrev == "TX")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Houston" && c.StateAbbrev == "TX")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Houston" && c.StateAbbrev == "TX")?.Code
            },
            new City
            {
                CityName = "Phoenix",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Phoenix" && c.StateAbbrev == "AZ")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Phoenix" && c.StateAbbrev == "AZ")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Phoenix" && c.StateAbbrev == "AZ")?.Code,
            },
            new City
            {
                CityName = "Philadelphia",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Philadelphia" && c.StateAbbrev == "PA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Philadelphia" && c.StateAbbrev == "PA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Philadelphia" && c.StateAbbrev == "PA")?.Code
            },
            new City
            {
                CityName = "San Antonio",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "San Antonio" && c.StateAbbrev == "TX")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "San Antonio" && c.StateAbbrev == "TX")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "San Antonio" && c.StateAbbrev == "TX")?.Code
            },
            new City
            {
                CityName = "San Diego",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "San Diego" && c.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "San Diego" && c.StateAbbrev == "CA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "San Diego" && c.StateAbbrev == "CA")?.Code
            },
            new City
            {
                CityName = "Dallas",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Dallas" && c.StateAbbrev == "TX")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Dallas" && c.StateAbbrev == "TX")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Dallas" && c.StateAbbrev == "TX")?.Code
            },
            new City
            {
                CityName = "Baltimore",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Baltimore" && c.StateAbbrev == "MD")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Baltimore" && c.StateAbbrev == "MD")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Baltimore" && c.StateAbbrev == "MD")?.Code,
            },
            new City
            {
                CityName = "Milwaukee",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Milwaukee" && c.StateAbbrev == "MN")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Milwaukee" && c.StateAbbrev == "MN")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Milwaukee" && c.StateAbbrev == "MN")?.Code,
            },
            new City
            {
                CityName = "Albuquerque",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Albuquerque" && c.StateAbbrev == "NM")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Albuquerque" && c.StateAbbrev == "NM")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Albuquerque" && c.StateAbbrev == "NM")?.Code,
            },

           new City
            {
                CityName = "Tucson",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Tucson" && c.StateAbbrev == "AZ")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Tucson" && c.StateAbbrev == "AZ")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Tucson" && c.StateAbbrev == "AZ")?.Code,
            },
            new City
            {
                CityName = "Fresno",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Fresno" && c.StateAbbrev == "CA")?.Code,
            },
            new City
            {
                CityName = "Sacramento",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.Code,
            },
            new City
            {
                CityName = "Kansas City",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Kansas City" && c.StateAbbrev == "MO")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Kansas City" && c.StateAbbrev == "MO")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Kansas City" && c.StateAbbrev == "MO")?.Code,
            },
            new City
            {
                CityName = "Long Beach",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Long Beach" && c.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Long Beach" && c.StateAbbrev == "CA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Long Beach" && c.StateAbbrev == "CA")?.Code,
            },
            new City
            {
                CityName = "Mesa",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Mesa" && c.StateAbbrev == "NM")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Mesa" && c.StateAbbrev == "NM")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Mesa" && c.StateAbbrev == "NM")?.Code,
            },

            new City
            {
                CityName = "Atlanta",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Atlanta" && c.StateAbbrev == "GA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Atlanta" && c.StateAbbrev == "GA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Atlanta" && c.StateAbbrev == "GA")?.Code
            },
            new City
            {
                CityName = "Colorado Springs",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Colorado Springs" && c.StateAbbrev == "CO")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Colorado Springs" && c.StateAbbrev == "CO")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Colorado Springs" && c.StateAbbrev == "CO")?.Code
            },
            new City
            {
                CityName = "Raleigh",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Raleigh" && c.StateAbbrev == "NC")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Raleigh" && c.StateAbbrev == "NC")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Raleigh" && c.StateAbbrev == "NC")?.Code
            },
            new City
            {
                CityName = "Miami",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Miami" && c.StateAbbrev == "FL")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Miami" && c.StateAbbrev == "FL")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Miami" && c.StateAbbrev == "FL")?.Code
            },
            new City
            {
                CityName = "Oakland",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Oakland" && c.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Oakland" && c.StateAbbrev == "CA")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Oakland" && c.StateAbbrev == "CA")?.Code
            },
            new City
            {
                CityName = "Minneapolis",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Minneapolis" && c.StateAbbrev == "MN")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Minneapolis" && c.StateAbbrev == "MN")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Minneapolis" && c.StateAbbrev == "MN")?.Code,
            },
            new City
            {
                CityName = "Tulsa",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Tulsa" && c.StateAbbrev == "OK")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Tulsa" && c.StateAbbrev == "OK")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Tulsa" && c.StateAbbrev == "OK")?.Code
            },
            new City
            {
                CityName = "Cleveland",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Cleveland" && c.StateAbbrev == "OH")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Cleveland" && c.StateAbbrev == "OH")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Cleveland" && c.StateAbbrev == "OH")?.Code
            },
            new City
            {
                CityName = "Wichita",
                StateAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Wichita" && c.StateAbbrev == "KS")?.StateAbbrev,
                RegionAbbrev = context.PostalCodes.FirstOrDefault(c => c.CityName == "Wichita" && c.StateAbbrev == "KS")?.RegionAbbrev,
                Code = context.PostalCodes.FirstOrDefault(c => c.CityName == "Wichita" && c.StateAbbrev == "KS")?.Code
            },
            new City
            {
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

        private static async Task SeedAddressesAsync(ApplicationDbContext context)
        {
            if (context.Addresses.Any())
            {
                return;
            }
            var addresses = new List<Address>
            {
                new Address
                {
                    Number = "8969",
                    Street = "Rosetta Circle",
                    CityName = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.CityName,
                    PostalCode = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.Code,
                    StateAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.StateAbbrev,
                    RegionAbbrev = context.Cities.FirstOrDefault(c => c.CityName == "Sacramento" && c.StateAbbrev == "CA")?.RegionAbbrev,
                    Type = context.AddressTypes.FirstOrDefault(a => a.Type == "Home")?.Type,

                }
            };

            await context.Addresses.AddRangeAsync(addresses);
            await context.SaveChangesAsync();
        }
    }
}
