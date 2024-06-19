using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SudaneseExpSYS.Migrations
{
    /// <inheritdoc />
    public partial class EditState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "states",
                newName: "SId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SId",
                table: "states",
                newName: "Id");
        }
    }
}
