using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SudaneseExpSYS.Migrations
{
    /// <inheritdoc />
    public partial class EditProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Degree",
                table: "profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SId",
                table: "profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "stateSId",
                table: "profiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_profiles_stateSId",
                table: "profiles",
                column: "stateSId");

            migrationBuilder.AddForeignKey(
                name: "FK_profiles_states_stateSId",
                table: "profiles",
                column: "stateSId",
                principalTable: "states",
                principalColumn: "SId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profiles_states_stateSId",
                table: "profiles");

            migrationBuilder.DropIndex(
                name: "IX_profiles_stateSId",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "SId",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "stateSId",
                table: "profiles");
        }
    }
}
