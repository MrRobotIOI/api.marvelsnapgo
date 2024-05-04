using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarHammer40KAPI.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "MSCards",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "MSCards",
                newName: "latitude");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "MSCards",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "MSCards",
                newName: "Latitude");
        }
    }
}
