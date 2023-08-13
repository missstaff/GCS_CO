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
            await SeedPostalCodesAsync(context);
            await SeedStatesAsync(context);
            await SeedCitiesAsync(context);
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
                    NormalizedEmail= teamMemberEmail,
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

            var regions = new List<Models.Region>
            {
                new Models.Region { RegionName = "North", RegionAbbrev = "N" },
                new Models.Region { RegionName = "Northwest", RegionAbbrev = "NW" },
                new Models.Region { RegionName = "Northeast", RegionAbbrev = "NE" },
                new Models.Region { RegionName = "South", RegionAbbrev = "S" },
                new Models.Region { RegionName = "Southwest", RegionAbbrev = "SW" },
                new Models.Region { RegionName = "Southeast", RegionAbbrev = "SE" },
                new Models.Region { RegionName = "West", RegionAbbrev = "W" },
                new Models.Region { RegionName = "Midwest", RegionAbbrev = "MW" },
                new Models.Region { RegionName = "East", RegionAbbrev = "E" },
            };

            await context.Regions.AddRangeAsync(regions);
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
                new PostalCode { Code = "10001", City = "New York City", State = "NY" },
                new PostalCode { Code = "90001", City = "Los Angeles", State = "CA" },
                new PostalCode { Code = "60601", City = "Chicago", State = "IL" },
                new PostalCode { Code = "77001", City = "Houston", State = "TX" },
                new PostalCode { Code = "85001", City = "Phoenix", State = "AZ" },
                new PostalCode { Code = "19101", City = "Philadelphia", State = "PA" },
                new PostalCode { Code = "78201", City = "San Antonio", State = "TX" },
                new PostalCode { Code = "92101", City = "San Diego", State = "CA" },
                new PostalCode { Code = "75201", City = "Dallas", State = "TX" },
                new PostalCode { Code = "21201", City = "Baltimore", State = "MD" },
                new PostalCode { Code = "53201", City = "Milwaukee", State = "WI" },
                new PostalCode { Code = "87101", City = "Albuquerque", State = "NM" },
                new PostalCode { Code = "85701", City = "Tucson", State = "AZ" },
                new PostalCode { Code = "93701", City = "Fresno", State = "CA" },
                new PostalCode { Code = "95814", City = "Sacramento", State = "CA" },
                new PostalCode { Code = "64101", City = "Kansas City", State = "MO" },
                new PostalCode { Code = "90801", City = "Long Beach", State = "CA" },
                new PostalCode { Code = "85201", City = "Mesa", State = "AZ" },
                new PostalCode { Code = "30301", City = "Atlanta", State = "GA" },
                new PostalCode { Code = "80901", City = "Colorado Springs", State = "CO" },
                new PostalCode { Code = "27601", City = "Raleigh", State = "NC" },
                new PostalCode { Code = "33101", City = "Miami", State = "FL" },
                new PostalCode { Code = "94601", City = "Oakland", State = "CA" },
                new PostalCode { Code = "55401", City = "Minneapolis", State = "MN" },
                new PostalCode { Code = "74101", City = "Tulsa", State = "OK" },
                new PostalCode { Code = "44101", City = "Cleveland", State = "OH" },
                new PostalCode { Code = "67201", City = "Wichita", State = "KS" },
                new PostalCode { Code = "76001", City = "Arlington", State = "TX" }
            };

            await context.PostalCodes.AddRangeAsync(postalCodes);
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
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "NY")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "NY")?.RegionAbbrev,

            },
            new City
            {
                CityName = "Los Angeles",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "CA")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Chicago",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "IL")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "IL")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Houston",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "TX")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "TX")?.RegionAbbrev,
            },
                new City
            {
                CityName = "Phoenix",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "AZ")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "AZ")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Philadelphia",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "PA")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "PA")?.RegionAbbrev,
            },
            new City
            {
                CityName = "San Antonio",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "TX")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "TX")?.RegionAbbrev,
            },
            new City
            {
                CityName = "San Diego",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "CA")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Dallas",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "TX")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "TX")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Baltimore",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "MD")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "MD")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Milwaukee",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "WI")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "WI")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Albuquerque",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "NM")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "NM")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Tucson",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "AZ")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "AZ")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Fresno",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "CA")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Sacramento",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "CA")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Kansas City",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "MO")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "MO")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Long Beach",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "CA")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Mesa",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "AZ")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "AZ")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Atlanta",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "GA")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "GA")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Colorado Springs",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "CO")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "CO")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Raleigh",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "NC")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "NC")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Miami",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "FL")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "FL")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Oakland",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "CA")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "CA")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Minneapolis",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "MN")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "MN")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Tulsa",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "OK")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "OK")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Cleveland",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "OH")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "OH")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Wichita",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "KS")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "KS")?.RegionAbbrev,
            },
            new City
            {
                CityName = "Arlington",
                StateAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "TX")?.StateAbbrev,
                RegionAbbrev = context.States.FirstOrDefault(s => s.StateAbbrev == "TX")?.RegionAbbrev,
            },
        };

            await context.Cities.AddRangeAsync(cities);
            await context.SaveChangesAsync();
        }
    }
}
