using GCS_CO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace GCS_CO.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet <AddressType> AddressTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("GCS");

            builder.Entity<AppUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable(name: "RoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable(name: "UserTokens");
            });

            builder.Entity<Region>()
                .HasKey(r => r.RegionId);

            builder.Entity<Region>()
                .HasMany(r => r.States)
                .WithOne(s => s.Region)
                .HasPrincipalKey(r => r.RegionAbbrev)
                .HasForeignKey(s => s.RegionAbbrev)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<State>()
                .HasKey(s => s.StateId);

            builder.Entity<State>()
                .HasOne(s => s.Region)
                .WithMany(r => r.States)
                .HasForeignKey(s => s.RegionAbbrev)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<State>()
               .HasMany(pc => pc.PostalCodes)
               .WithOne(s => s.State)
               .HasPrincipalKey(s => s.StateAbbrev)
               .HasForeignKey(s => s.StateAbbrev)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();

            builder.Entity<State>()
               .HasMany(c => c.Cities)
               .WithOne(s => s.State)
               .HasPrincipalKey(s => s.StateAbbrev)
               .HasForeignKey(s => s.StateAbbrev)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();

            builder.Entity<PostalCode>()
                .HasOne(pc => pc.State)
                .WithMany(s => s.PostalCodes)
                .HasForeignKey(pc => pc.StateAbbrev)  //Use StateAbbrev as the foreign key
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();


            builder.Entity<City>()
                .HasOne(c => c.State)
                .WithMany(c => c.Cities)
                .HasForeignKey(pc => pc.StateAbbrev)  //Use StateAbbrev as the foreign key
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<PostalCode>()
                .HasKey(pc => new { pc.CityName, pc.StateAbbrev });

            builder.Entity<City>()
                .HasKey(c => c.CityId);


            builder.Entity<PostalCode>()
                .HasOne<City>(c => c.City)
                .WithOne(pc => pc.PostalCode)
                .HasForeignKey<City>(c => new { c.CityName, c.StateAbbrev })
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.Entity<City>()
                .HasMany(c => c.Addresses)
                .WithOne(c => c.City)
                .HasPrincipalKey(c => new {c.CityName, c.StateAbbrev})
                .HasForeignKey(c => new { c.CityName, c.StateAbbrev })
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Address>()
                .HasKey(a => a.AddressId);

            builder.Entity<Address>()
               .HasOne(a => a.City)
               .WithMany(a => a.Addresses)
               .HasForeignKey(c => new { c.CityName, c.StateAbbrev })
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();

            builder.Entity<AddressType>()
                .HasKey(a => a.AddressTypeId);

            builder.Entity<AddressType>()
                .HasMany(a => a.Addresses)
                .WithOne(a => a.AddressType)
                .HasPrincipalKey(a => a.Type)
                .HasForeignKey(a => a.Type)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Address>()
                .HasOne(a => a.AddressType)
                .WithMany(a => a.Addresses)
                .HasForeignKey(a => a.Type)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Employee>()
                .HasKey(e => e.EmployeeId);

            builder.Entity<Region>()
                .HasMany(r => r.Employees)
                .WithOne(s => s.Region)
                .HasPrincipalKey(r => r.RegionAbbrev)
                .HasForeignKey(s => s.RegionAbbrev)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Employee>()
                .HasOne(s => s.Region)
                .WithMany(r => r.Employees)
                .HasForeignKey(s => s.RegionAbbrev)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<Employee>()
                .HasMany(e => e.Addresses) // Employee has many Addresses
                .WithOne(a => a.Employee)  // Address has one Employee
                .HasForeignKey(a => a.EmployeeId) // Foreign key
                .OnDelete(DeleteBehavior.Cascade) // Cascade delete if an employee is deleted
                .IsRequired(); // Addresses are required for an Employee


            builder.Entity<Employee>()
                .HasMany(e => e.EmployeeSkills) // Employee has many EmployeeSkills
                .WithOne(es => es.Employee)      // EmployeeSkill has one Employee
                .HasForeignKey(es => es.EmployeeId) // Foreign key
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if an employee is deleted

            builder.Entity<EmployeeSkill>()
                .HasKey(es => es.EmployeeSkillId);

            builder.Entity<EmployeeSkill>()
                .HasOne(es => es.Employee)
                .WithMany(e => e.EmployeeSkills)
                .HasForeignKey(es => es.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<EmployeeSkill>()
                .HasOne(es => es.Skill)
                .WithMany(s => s.EmployeeSkills)
                .HasPrincipalKey(s => s.SkillName)
                .HasForeignKey(es => es.SkillName)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
