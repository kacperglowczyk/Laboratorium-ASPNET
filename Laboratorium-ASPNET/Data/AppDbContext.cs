using Microsoft.EntityFrameworkCore;
using Data.Entities;
using System;

namespace Data;

    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<ComputerEntity> Computers { get; set; }

        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "database.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ContactEntity seed data
            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity
                {
                    Id = 1,
                    Name = "Adam Nowak",
                    Email = "adam.nowak@example.com",
                    Phone = "123456789",
                    Birth = new DateTime(2000, 1, 15)
                },
                new ContactEntity
                {
                    Id = 2,
                    Name = "Ewa Kowalska",
                    Email = "ewa.kowalska@example.com",
                    Phone = "987654321",
                    Birth = new DateTime(1995, 8, 25)
                }
            );

            // ComputerEntity seed data
            modelBuilder.Entity<ComputerEntity>().HasData(
                new ComputerEntity
                {
                    Id = 1,
                    Name = "Gaming PC",
                    Processor = "Intel Core i9",
                    Memory = 32,
                    Graphics = "NVIDIA RTX 3080",
                    Maker = "Custom Build",
                    ProductionDate = new DateTime(2022, 5, 10),
                    Description = "High-end gaming PC."
                },
                new ComputerEntity
                {
                    Id = 2,
                    Name = "Workstation",
                    Processor = "AMD Ryzen 9",
                    Memory = 64,
                    Graphics = "AMD Radeon Pro",
                    Maker = "Dell",
                    ProductionDate = new DateTime(2021, 11, 20),
                    Description = "Powerful workstation for rendering."
                }
            );
        }
    }

