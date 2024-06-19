using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SudaneseExpSYS.Migrations
{
    /// <inheritdoc />
    public partial class addUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "294728ae-7944-4cc6-ab98-7bc28f57a6fd", "28badc8a-f03a-4aa9-8bcc-7b0bd0e2c55e", "Admin", "admin" },
                    { "d0f18b95-d8ee-4bb2-89a4-44693d25e651", "f3bacb05-a8c1-4e18-9436-257792be9c3f", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "294728ae-7944-4cc6-ab98-7bc28f57a6fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0f18b95-d8ee-4bb2-89a4-44693d25e651");
        }
    }
}
