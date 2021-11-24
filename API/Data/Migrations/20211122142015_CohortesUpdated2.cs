using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class CohortesUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_parentId",
                table: "Context");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Category_CategoryId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "idParent",
                table: "Context");

            

            migrationBuilder.RenameColumn(
                name: "parentId",
                table: "Context",
                newName: "ParentId");

           

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Course",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_TeacherId",
                table: "Course",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Context",
                column: "ParentId",
                principalTable: "Context",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_TeacherId",
                table: "Course",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Category_CategoryId",
                table: "Course",
                column: "CategoryId",
                principalTable: "Context",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Context");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_TeacherId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Category_CategoryId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_TeacherId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Course",
                newName: "IdCategory");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Context",
                newName: "parentId");

           

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Course",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_parentId",
                table: "Context",
                column: "parentId",
                principalTable: "Context",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Category_CategoryId",
                table: "Course",
                column: "CategoryId",
                principalTable: "Context",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
