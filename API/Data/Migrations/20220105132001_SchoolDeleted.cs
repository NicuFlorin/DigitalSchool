using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class SchoolDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_School_SchoolId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Context_School_SchoolId",
                table: "Context");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentEnrollment",
                table: "StudentEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_StudentEnrollment_AppUserId",
                table: "StudentEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_Context_SchoolId",
                table: "Context");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SchoolId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Context");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "AspNetUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentEnrollment",
                table: "StudentEnrollment",
                columns: new[] { "AppUserId", "CohortId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentEnrollment",
                table: "StudentEnrollment");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentEnrollment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Context",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentEnrollment",
                table: "StudentEnrollment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_AppUserId",
                table: "StudentEnrollment",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Context_SchoolId",
                table: "Context",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SchoolId",
                table: "AspNetUsers",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_School_SchoolId",
                table: "AspNetUsers",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Context_School_SchoolId",
                table: "Context",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
