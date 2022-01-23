using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class QuestionAltered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileUpload_Question_QuestionId",
                table: "FileUpload");

            migrationBuilder.DropIndex(
                name: "IX_FileUpload_QuestionId",
                table: "FileUpload");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "FileUpload");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Question",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_ImageId",
                table: "Question",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_FileUpload_ImageId",
                table: "Question",
                column: "ImageId",
                principalTable: "FileUpload",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_FileUpload_ImageId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_ImageId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Question");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Question",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Question",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "FileUpload",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileUpload_QuestionId",
                table: "FileUpload",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileUpload_Question_QuestionId",
                table: "FileUpload",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
