using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class SubmitsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MaximumGrade",
                table: "Upload",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "GradeToPass",
                table: "Upload",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Assignment_MaximumGrade",
                table: "Upload",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Assignment_GradeToPass",
                table: "Upload",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Mark",
                table: "Question",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Submit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentAppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentCohortId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignmentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submit_StudentEnrollment_StudentAppUserId_StudentCohortId",
                        columns: x => new { x.StudentAppUserId, x.StudentCohortId },
                        principalTable: "StudentEnrollment",
                        principalColumns: new[] { "AppUserId", "CohortId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submit_Upload_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Upload",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Submit_AssignmentId",
                table: "Submit",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Submit_StudentAppUserId_StudentCohortId",
                table: "Submit",
                columns: new[] { "StudentAppUserId", "StudentCohortId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Submit");

            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Question");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaximumGrade",
                table: "Upload",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GradeToPass",
                table: "Upload",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Assignment_MaximumGrade",
                table: "Upload",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Assignment_GradeToPass",
                table: "Upload",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);
        }
    }
}
