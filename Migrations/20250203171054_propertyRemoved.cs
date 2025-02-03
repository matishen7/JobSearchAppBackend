using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class propertyRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Removed",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Removed",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Removed",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Removed",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Removed",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Removed",
                table: "Applications");
        }
    }
}
