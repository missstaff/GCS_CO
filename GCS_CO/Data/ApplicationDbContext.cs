using GCS_CO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GCS_CO.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

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

            builder.Entity<PostalCode>()
                .HasKey(pc => pc.PostalCodeId);

            builder.Entity<PostalCode>()
                .HasOne(pc => pc.State)
                .WithMany(s => s.PostalCodes)
                .HasForeignKey(pc => pc.StateAbbrev) // Use StateAbbrev as the foreign key
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
