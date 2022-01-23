using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class ResourceAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssignmentSubmit_FileId",
                table: "AssignmentSubmit");

            migrationBuilder.AlterColumn<double>(
                name: "Grade",
                table: "AssignmentSubmit",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentSubmit_FileId",
                table: "AssignmentSubmit",
                column: "FileId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssignmentSubmit_FileId",
                table: "AssignmentSubmit");

            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "AssignmentSubmit",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentSubmit_FileId",
                table: "AssignmentSubmit",
                column: "FileId");
        }
    }
}
