using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class RenameJobListingIdToJobId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Jobs",
                newName: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Jobs",
                newName: "Id");
        }
    }
}
