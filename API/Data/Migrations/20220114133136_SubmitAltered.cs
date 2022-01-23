using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class SubmitAltered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Submit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentEnrollment",
                table: "StudentEnrollment");

            migrationBuilder.AddColumn<bool>(
                name: "AllowGoingBack",
                table: "Upload",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentEnrollment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<double>(
                name: "WrongAnswearSanction",
                table: "Question",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentEnrollment",
                table: "StudentEnrollment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AssignmentSubmit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    Feedback = table.Column<string>(type: "TEXT", nullable: true),
                    Grade = table.Column<decimal>(type: "TEXT", nullable: false),
                    FileId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentSubmit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentSubmit_FileUpload_FileId",
                        column: x => x.FileId,
                        principalTable: "FileUpload",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentSubmit_StudentEnrollment_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentEnrollment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentSubmit_Upload_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Upload",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizSubmit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FinalGrade = table.Column<double>(type: "REAL", nullable: false),
                    DateSubmit = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IndexCurrentQuestion = table.Column<int>(type: "INTEGER", nullable: false),
                    QuizId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizSubmit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizSubmit_StudentEnrollment_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentEnrollment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizSubmit_Upload_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Upload",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuizSubmitId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    ShortAnswear = table.Column<string>(type: "TEXT", nullable: true),
                    AnswearId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswear", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswear_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswear_QuizSubmit_QuizSubmitId",
                        column: x => x.QuizSubmitId,
                        principalTable: "QuizSubmit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChoiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionAnswearId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answear", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answear_Choice_ChoiceId",
                        column: x => x.ChoiceId,
                        principalTable: "Choice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answear_QuestionAnswear_QuestionAnswearId",
                        column: x => x.QuestionAnswearId,
                        principalTable: "QuestionAnswear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_AppUserId",
                table: "StudentEnrollment",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Answear_ChoiceId",
                table: "Answear",
                column: "ChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Answear_QuestionAnswearId",
                table: "Answear",
                column: "QuestionAnswearId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentSubmit_AssignmentId",
                table: "AssignmentSubmit",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentSubmit_FileId",
                table: "AssignmentSubmit",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentSubmit_StudentId",
                table: "AssignmentSubmit",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswear_QuestionId",
                table: "QuestionAnswear",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswear_QuizSubmitId",
                table: "QuestionAnswear",
                column: "QuizSubmitId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSubmit_QuizId",
                table: "QuizSubmit",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizSubmit_StudentId",
                table: "QuizSubmit",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answear");

            migrationBuilder.DropTable(
                name: "AssignmentSubmit");

            migrationBuilder.DropTable(
                name: "QuestionAnswear");

            migrationBuilder.DropTable(
                name: "QuizSubmit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentEnrollment",
                table: "StudentEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_StudentEnrollment_AppUserId",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "AllowGoingBack",
                table: "Upload");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "WrongAnswearSanction",
                table: "Question");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentEnrollment",
                table: "StudentEnrollment",
                columns: new[] { "AppUserId", "CohortId" });

            migrationBuilder.CreateTable(
                name: "Submit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssignmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    StudentAppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentCohortId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
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
    }
}
