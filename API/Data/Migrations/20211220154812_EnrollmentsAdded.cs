using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class EnrollmentsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cohort_CohortId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cohort_Context_ContextId",
                table: "Cohort");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CohortId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CohortId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ContextId",
                table: "Cohort",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "StudentEnrollment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CohortId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrollment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEnrollment_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEnrollment_Cohort_CohortId",
                        column: x => x.CohortId,
                        principalTable: "Cohort",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherEnrollment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherEnrollment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherEnrollment_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherEnrollment_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_AppUserId",
                table: "StudentEnrollment",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_CohortId",
                table: "StudentEnrollment",
                column: "CohortId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherEnrollment_AppUserId",
                table: "TeacherEnrollment",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherEnrollment_CourseId",
                table: "TeacherEnrollment",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cohort_Context_ContextId",
                table: "Cohort",
                column: "ContextId",
                principalTable: "Context",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cohort_Context_ContextId",
                table: "Cohort");

            migrationBuilder.DropTable(
                name: "StudentEnrollment");

            migrationBuilder.DropTable(
                name: "TeacherEnrollment");

            migrationBuilder.AlterColumn<int>(
                name: "ContextId",
                table: "Cohort",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "CohortId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CohortId",
                table: "AspNetUsers",
                column: "CohortId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cohort_CohortId",
                table: "AspNetUsers",
                column: "CohortId",
                principalTable: "Cohort",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cohort_Context_ContextId",
                table: "Cohort",
                column: "ContextId",
                principalTable: "Context",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
