using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganizationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "computers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "computers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "birth_date",
                table: "contacts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 31, 20, 53, 56, 881, DateTimeKind.Local).AddTicks(7560),
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 101);

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Regon = table.Column<string>(type: "TEXT", nullable: false),
                    Nip = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Region = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "organizations",
                columns: new[] { "Id", "Nip", "Regon", "Title" },
                values: new object[,]
                {
                    { 101, "83492384", "13424234", "WSEI" },
                    { 102, "2498534", "0873439249", "Firma" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_organizations_OrganizationId",
                table: "contacts",
                column: "OrganizationId",
                principalTable: "organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_organizations_OrganizationId",
                table: "contacts");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "contacts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "birth_date",
                table: "contacts",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2024, 12, 31, 20, 53, 56, 881, DateTimeKind.Local).AddTicks(7560));

            migrationBuilder.InsertData(
                table: "computers",
                columns: new[] { "Id", "Description", "Graphics", "Maker", "Memory", "Name", "Processor", "production_date" },
                values: new object[,]
                {
                    { 1, "High-end gaming PC.", "NVIDIA RTX 3080", "Custom Build", 32, "Gaming PC", "Intel Core i9", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Powerful workstation for rendering.", "AMD Radeon Pro", "Dell", 64, "Workstation", "AMD Ryzen 9", new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "birth_date", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "adam.nowak@example.com", "Adam Nowak", "123456789" },
                    { 2, new DateTime(1995, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ewa.kowalska@example.com", "Ewa Kowalska", "987654321" }
                });
        }
    }
}
