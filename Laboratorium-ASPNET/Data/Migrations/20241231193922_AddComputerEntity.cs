using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddComputerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Processor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Memory = table.Column<int>(type: "INTEGER", nullable: false),
                    Graphics = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Maker = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    production_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "computers",
                columns: new[] { "Id", "Description", "Graphics", "Maker", "Memory", "Name", "Processor", "production_date" },
                values: new object[,]
                {
                    { 1, "High-end gaming PC.", "NVIDIA RTX 3080", "Custom Build", 32, "Gaming PC", "Intel Core i9", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Powerful workstation for rendering.", "AMD Radeon Pro", "Dell", 64, "Workstation", "AMD Ryzen 9", new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "birth_date", "Email", "Name", "Phone" },
                values: new object[] { new DateTime(2000, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "adam.nowak@example.com", "Adam Nowak", "123456789" });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "birth_date", "Email", "Name", "Phone" },
                values: new object[] { new DateTime(1995, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ewa.kowalska@example.com", "Ewa Kowalska", "987654321" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "computers");

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "birth_date", "Email", "Name", "Phone" },
                values: new object[] { new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "adam@wsei.edu.pl", "Adam", "127813268163" });

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "birth_date", "Email", "Name", "Phone" },
                values: new object[] { new DateTime(1999, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ewa@wsei.edu.pl", "Ewa", "293443823478" });
        }
    }
}
