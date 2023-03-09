using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactManager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Married = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactData", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ContactData",
                columns: new[] { "Id", "DateOfBirth", "Married", "Name", "Phone", "Salary" },
                values: new object[,]
                {
                    { 1, new DateTime(2008, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Anna", "0987654321", 5000m },
                    { 2, new DateTime(2001, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Bob", "0987644441", 4000m },
                    { 3, new DateTime(1999, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Tom", "0987644490", 14000m },
                    { 4, new DateTime(2003, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Maria", "0667644441", 8000m },
                    { 5, new DateTime(1999, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "David", "0777644490", 10000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactData");
        }
    }
}
