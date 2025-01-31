using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class JobApplicationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_UserId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "Resume",
                table: "Applications",
                newName: "ResumeUrl");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Applications",
                newName: "JobListingId");

            migrationBuilder.RenameColumn(
                name: "AppliedDate",
                table: "Applications",
                newName: "ApplicationDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Applications",
                newName: "JobApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_JobId",
                table: "Applications",
                newName: "IX_Applications_JobListingId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Applications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantEmail",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantName",
                table: "Applications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantPhone",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobListingId",
                table: "Applications",
                column: "JobListingId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_UserId",
                table: "Applications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobListingId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_UserId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicantEmail",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicantName",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicantPhone",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "ResumeUrl",
                table: "Applications",
                newName: "Resume");

            migrationBuilder.RenameColumn(
                name: "JobListingId",
                table: "Applications",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "ApplicationDate",
                table: "Applications",
                newName: "AppliedDate");

            migrationBuilder.RenameColumn(
                name: "JobApplicationId",
                table: "Applications",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_JobListingId",
                table: "Applications",
                newName: "IX_Applications_JobId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_UserId",
                table: "Applications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
