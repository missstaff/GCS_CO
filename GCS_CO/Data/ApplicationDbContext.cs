﻿using GCS_CO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Configuration;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Channels;

namespace GCS_CO.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");

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
              .HasKey(r => r.RegionId);  // Define primary key for the Region entity

            builder.Entity<Region>()
                .HasMany(r => r.States)  // A region can have multiple states
                .WithOne(s => s.Region)  // Each state belongs to a region
                .HasPrincipalKey(r => r.RegionAbbrev)
                .HasForeignKey(s => s.RegionAbbrev)  // Use RegionAbbrev as the foreign key
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();


            builder.Entity<State>()
                .HasKey(s => s.StateId);  // Define primary key for the State entity

            builder.Entity<State>()
                .HasOne(s => s.Region)  // Each state belongs to a region
                .WithMany(r => r.States)  // A region can have multiple states
                .HasForeignKey(s => s.RegionAbbrev)  // Use RegionAbbrev as the foreign key
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Entity<State>()
               .HasMany(c => c.Cities) // A state can have multiple cities
               .WithOne(s => s.State) // Each city belongs to a state
               .HasPrincipalKey(s => s.StateAbbrev)
               .HasForeignKey(s => s.StateAbbrev)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();


            builder.Entity<City>()
                .HasKey(c => c.CityId);  // Define primary key for the City entity

            builder.Entity<City>()
                .HasOne(c => c.State)  // Each city belongs to a state
                .WithMany(s => s.Cities)  // A state can have multiple cities
                .HasForeignKey(c => c.StateAbbrev)  // Use StateAbbrev as the foreign key
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
   
        }

    }
}