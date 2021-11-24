using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class CohortUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cohort_School_SchoolId",
                table: "Cohort");

            migrationBuilder.DropIndex(
                name: "IX_Cohort_SchoolId",
                table: "Cohort");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Cohort");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Cohort",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cohort_SchoolId",
                table: "Cohort",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cohort_School_SchoolId",
                table: "Cohort",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
