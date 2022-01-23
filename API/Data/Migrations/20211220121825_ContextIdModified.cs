using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class ContextIdModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cohort_Context_ContextId",
                table: "Cohort");

            migrationBuilder.AlterColumn<int>(
                name: "ContextId",
                table: "Cohort",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Cohort_Context_ContextId",
                table: "Cohort",
                column: "ContextId",
                principalTable: "Context",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cohort_Context_ContextId",
                table: "Cohort");

            migrationBuilder.AlterColumn<int>(
                name: "ContextId",
                table: "Cohort",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cohort_Context_ContextId",
                table: "Cohort",
                column: "ContextId",
                principalTable: "Context",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
