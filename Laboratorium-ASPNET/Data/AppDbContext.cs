using Microsoft.EntityFrameworkCore;
using Data.Entities;
using System;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<ComputerEntity> Computers { get; set; } // Added DbSet for Computers

        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "database.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration for relationships
            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(e => e.Address);

            modelBuilder.Entity<ContactEntity>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<ContactEntity>()
                .Property(e => e.OrganizationId)
                .HasDefaultValue(101);

            modelBuilder.Entity<ContactEntity>()
                .Property(e => e.Birth)
                .HasDefaultValue(DateTime.Now);

            // Initial Data
            modelBuilder.Entity<OrganizationEntity>()
                .ToTable("organizations")
                .HasData(
                    new OrganizationEntity
                    {
                        Id = 101,
                        Title = "WSEI",
                        Nip = "83492384",
                        Regon = "13424234",
                    },
                    new OrganizationEntity
                    {
                        Id = 102,
                        Title = "Firma",
                        Nip = "2498534",
                        Regon = "0873439249",
                    }
                );
        }
    }
}
