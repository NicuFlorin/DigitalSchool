using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class CohortUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContextId",
                table: "Cohort",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cohort_ContextId",
                table: "Cohort",
                column: "ContextId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cohort_Category_ContextId",
                table: "Cohort",
                column: "ContextId",
                principalTable: "Context",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cohort_Category_ContextId",
                table: "Cohort");

            migrationBuilder.DropIndex(
                name: "IX_Cohort_ContextId",
                table: "Cohort");

            migrationBuilder.DropColumn(
                name: "ContextId",
                table: "Cohort");
        }
    }
}
