using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SudaneseExpSYS.Migrations
{
    /// <inheritdoc />
    public partial class removedegree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "profiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Degree",
                table: "profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
