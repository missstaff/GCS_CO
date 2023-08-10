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

            var skills = new Skill[]
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

            var regions = new Region[]
            {
                new Region { Name = "North", Abbreviation = "N" },
                new Region { Name = "Northwest", Abbreviation = "NW" },
                new Region { Name = "Northeast", Abbreviation = "NE" },
                new Region { Name = "South", Abbreviation = "S" },
                new Region { Name = "Southwest", Abbreviation = "SW" },
                new Region { Name = "Southeast", Abbreviation = "SE" },
                new Region { Name = "West", Abbreviation = "W" },
                new Region { Name = "Midwest", Abbreviation = "MW" },
                new Region { Name = "East", Abbreviation = "E" },
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
            var states = new List<State>
            {
                new State { Name = "Alabama", Abbreviation = "AL", Region = context.Regions.Single(r => r.Abbreviation == "S") },
                new State { Name = "Alaska", Abbreviation = "AK", Region = context.Regions.Single(r => r.Abbreviation == "NW") },
                new State { Name = "Arizona", Abbreviation = "AZ", Region = context.Regions.Single(r => r.Abbreviation == "SW") },
                new State { Name = "Arkansas", Abbreviation = "AR", Region = context.Regions.Single(r => r.Abbreviation == "S") },
                new State { Name = "California", Abbreviation = "CA", Region = context.Regions.Single(r => r.Abbreviation == "W") },
                new State { Name = "Colorado", Abbreviation = "CO", Region = context.Regions.Single(r => r.Abbreviation == "MW") },
                new State { Name = "Connecticut", Abbreviation = "CT", Region = context.Regions.Single(r => r.Abbreviation == "NE") },
                new State { Name = "Delaware", Abbreviation = "DE", Region = context.Regions.Single(r => r.Abbreviation == "NE") },
                new State { Name = "Florida", Abbreviation = "FL", Region = context.Regions.Single(r => r.Abbreviation == "SE") },
                new State { Name = "Georgia", Abbreviation = "GA", Region = context.Regions.Single(r => r.Abbreviation == "SE") },
                new State { Name = "Hawaii", Abbreviation = "HI", Region = context.Regions.Single(r => r.Abbreviation == "W") },
                new State { Name = "Idaho", Abbreviation = "ID", Region = context.Regions.Single(r => r.Abbreviation == "NW") },
                new State { Name = "Illinois", Abbreviation = "IL", Region = context.Regions.Single(r => r.Abbreviation == "MW") },
                new State { Name = "Indiana", Abbreviation = "IN", Region = context.Regions.Single(r => r.Abbreviation == "MW") },
                new State { Name = "Iowa", Abbreviation = "IA", Region = context.Regions.Single(r => r.Abbreviation == "MW") },
                new State { Name = "Kansas", Abbreviation = "KS", Region = context.Regions.Single(r => r.Abbreviation == "MW") },
                new State { Name = "Kentucky", Abbreviation = "KY", Region = context.Regions.Single(r => r.Abbreviation == "S") },
                new State { Name = "Louisiana", Abbreviation = "LA", Region = context.Regions.Single(r => r.Abbreviation == "S") },
                new State { Name = "Maine", Abbreviation = "ME", Region = context.Regions.Single(r => r.Abbreviation == "NE") },
                new State { Name = "Maryland", Abbreviation = "MD", Region = context.Regions.Single(r => r.Abbreviation == "NE") },
                new State { Name = "Massachusetts", Abbreviation = "MA", Region = context.Regions.Single(r => r.Abbreviation == "NE") },
                new State { Name = "Michigan", Abbreviation = "MI", Region = context.Regions.Single(r => r.Abbreviation == "MW") },
                new State { Name = "Minnesota", Abbreviation = "MN", Region = context.Regions.Single(r => r.Abbreviation == "MW") },
                new State { Name = "Mississippi", Abbreviation = "MS", Region = context.Regions.Single(r => r.Abbreviation == "S") },
                new State { Name = "Missouri", Abbreviation = "MO", Region = context.Regions.Single(r => r.Abbreviation == "MW") },
                new State { Name = "Montana", Abbreviation = "MT", Region = context.Regions.Single(r => r.Abbreviation == "NW") },
                new State { Name = "Nebraska", Abbreviation = "NE", Region = context.Regions.Single(r => r.Abbreviation == "MW") },
                new State { Name = "Nevada", Abbreviation = "NV", Region = context.Regions.Single(r => r.Abbreviation == "W") },
                new State { Name = "New Hampshire", Abbreviation = "NH", Region = context.Regions.Single(r => r.Abbreviation == "NE") },
                new State { Name = "New Jersey", Abbreviation = "NJ", Region = context.Regions.Single(r => r.Abbreviation == "NE") },
                new State { Name = "New Mexico", Abbreviation = "NM", Region = context.Regions.Single(r => r.Abbreviation == "SW") },
                new State { Name = "New York", Abbreviation = "NY", Region = context.Regions.Single(r => r.Abbreviation == "NE") },
                new State { Name = "North Carolina", Abbreviation = "NC", Region = context.Regions.Single(r => r.Abbreviation == "SE") },
                new State { Name = "North Dakota", Abbreviation = "ND", Region = context.Regions.Single(r => r.Abbreviation == "MW") },
                new State { Name = "Ohio", Abbreviation = "OH", Region = context.Regions.Single(r => r.Abbreviation == "MW") },
                new State { Name = "Oklahoma", Abbreviation = "OK", Region = context.Regions.Single(r => r.Abbreviation == "S") },
                new State { Name = "Oregon", Abbreviation = "OR", Region = context.Regions.Single(r => r.Abbreviation == "W") },
                new State { Name = "Pennsylvania", Abbreviation = "PA", Region = context.Regions.Single(r => r.Abbreviation == "NE") },
                new State { Name = "Rhode Island", Abbreviation = "RI", Region = context.Regions.Single(r => r.Abbreviation == "NE") },
                new State { Name = "South Carolina", Abbreviation = "SC", Region = context.Regions.Single(r => r.Abbreviation == "SE") },
                new State { Name = "South Dakota", Abbreviation = "SD", Region = context.Regions.Single(r => r.Abbreviation == "MW") },
                new State { Name = "Tennessee", Abbreviation = "TN", Region = context.Regions.Single(r => r.Abbreviation == "S") },
                new State { Name = "Texas", Abbreviation = "TX", Region = context.Regions.Single(r => r.Abbreviation == "S") },
                new State { Name = "Utah", Abbreviation = "UT", Region = context.Regions.Single(r => r.Abbreviation == "MW") },
                new State { Name = "Vermont", Abbreviation = "VT", Region = context.Regions.Single(r => r.Abbreviation == "NE") },
                new State { Name = "Virginia", Abbreviation = "VA", Region = context.Regions.Single(r => r.Abbreviation == "S") },
                new State { Name = "Washington", Abbreviation = "WA", Region = context.Regions.Single(r => r.Abbreviation == "NW") },
                new State { Name = "West Virginia", Abbreviation = "WV", Region = context.Regions.Single(r => r.Abbreviation == "S") },
                new State { Name = "Wisconsin", Abbreviation = "WI", Region = context.Regions.Single(r => r.Abbreviation == "MW") },
                new State { Name = "Wyoming", Abbreviation = "WY", Region = context.Regions.Single(r => r.Abbreviation == "W") }

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


                new City { Name = "New York City", State = context.States.FirstOrDefault(s => s.Abbreviation == "NY") ?? new State { Abbreviation = "NY", Name = "New York" } },
                new City { Name = "Los Angeles", State = context.States.FirstOrDefault(s => s.Abbreviation == "CA") ?? new State { Abbreviation = "CA", Name = "California" } },
                new City { Name = "Chicago", State = context.States.FirstOrDefault(s => s.Abbreviation == "IL") ?? new State { Abbreviation = "IL", Name = "Illinois" } },
                new City { Name = "Houston", State = context.States.FirstOrDefault(s => s.Abbreviation == "TX") ?? new State { Abbreviation = "TX", Name = "Texas" } },
                new City { Name = "Phoenix", State = context.States.FirstOrDefault(s => s.Abbreviation == "AZ") ?? new State { Abbreviation = "AZ", Name = "Arizona" } },
                new City { Name = "Philadelphia", State = context.States.FirstOrDefault(s => s.Abbreviation == "PA") ?? new State { Abbreviation = "PA", Name = "Pennsylvania" } },
                new City { Name = "San Antonio", State = context.States.FirstOrDefault(s => s.Abbreviation == "TX") ?? new State { Abbreviation = "TX", Name = "Texas" } },
                new City { Name = "San Diego", State = context.States.FirstOrDefault(s => s.Abbreviation == "CA") ?? new State { Abbreviation = "CA", Name = "California" } },
                new City { Name = "Dallas", State = context.States.FirstOrDefault(s => s.Abbreviation == "TX") ?? new State { Abbreviation = "TX", Name = "Texas" } },
                new City { Name = "Baltimore", State = context.States.FirstOrDefault(s => s.Abbreviation == "MD") ?? new State { Abbreviation = "MD", Name = "Maryland" } },
                new City { Name = "Milwaukee", State = context.States.FirstOrDefault(s => s.Abbreviation == "WI") ?? new State { Abbreviation = "WI", Name = "Wisconsin" } },
                new City { Name = "Albuquerque", State = context.States.FirstOrDefault(s => s.Abbreviation == "NM") ?? new State { Abbreviation = "NM", Name = "New Mexico" } },
                new City { Name = "Tucson", State = context.States.FirstOrDefault(s => s.Abbreviation == "AZ") ?? new State { Abbreviation = "AZ", Name = "Arizona" } },
                new City { Name = "Fresno", State = context.States.FirstOrDefault(s => s.Abbreviation == "CA") ?? new State { Abbreviation = "CA", Name = "California" } },
                new City { Name = "Sacramento", State = context.States.FirstOrDefault(s => s.Abbreviation == "CA") ?? new State { Abbreviation = "CA", Name = "California" } },
                new City { Name = "Kansas City", State = context.States.FirstOrDefault(s => s.Abbreviation == "MO") ?? new State { Abbreviation = "MO", Name = "Missouri" } },
                new City { Name = "Long Beach", State = context.States.FirstOrDefault(s => s.Abbreviation == "CA") ?? new State { Abbreviation = "CA", Name = "California" } },
                new City { Name = "Mesa", State = context.States.FirstOrDefault(s => s.Abbreviation == "AZ") ?? new State { Abbreviation = "AZ", Name = "Arizona" } },
                new City { Name = "Atlanta", State = context.States.FirstOrDefault(s => s.Abbreviation == "GA") ?? new State { Abbreviation = "GA", Name = "Georgia" } },
                new City { Name = "Colorado Springs", State = context.States.FirstOrDefault(s => s.Abbreviation == "CO") ?? new State { Abbreviation = "CO", Name = "Colorado" } },
                new City { Name = "Raleigh", State = context.States.FirstOrDefault(s => s.Abbreviation == "NC") ?? new State { Abbreviation = "NC", Name = "North Carolina" } },
                new City { Name = "Miami", State = context.States.FirstOrDefault(s => s.Abbreviation == "FL") ?? new State { Abbreviation = "FL", Name = "Florida" } },
                new City { Name = "Oakland", State = context.States.FirstOrDefault(s => s.Abbreviation == "CA") ?? new State { Abbreviation = "CA", Name = "California" } },
                new City { Name = "Minneapolis", State = context.States.FirstOrDefault(s => s.Abbreviation == "MN") ?? new State { Abbreviation = "MN", Name = "Minnesota" } },
                new City { Name = "Tulsa", State = context.States.FirstOrDefault(s => s.Abbreviation == "OK") ?? new State { Abbreviation = "OK", Name = "Oklahoma" } },
                new City { Name = "Cleveland", State = context.States.FirstOrDefault(s => s.Abbreviation == "OH") ?? new State { Abbreviation = "OH", Name = "Ohio" } },
                new City { Name = "Wichita", State = context.States.FirstOrDefault(s => s.Abbreviation == "KS") ?? new State { Abbreviation = "KS", Name = "Kansas" } },
                new City { Name = "Arlington", State = context.States.FirstOrDefault(s => s.Abbreviation == "TX") ?? new State { Abbreviation = "TX", Name = "Texas" } }

            };

            foreach (var city in cities)
            {
                city.Region = city.State.Region;
            }

            await context.Cities.AddRangeAsync(cities);
            await context.SaveChangesAsync();
        }
    }
}
