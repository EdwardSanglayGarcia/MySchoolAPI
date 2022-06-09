using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Test.Data.Migrations
{
    public partial class DesignRevisions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_People_PersonId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Grades",
                newName: "GradeListId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                newName: "IX_Grades_GradeListId");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GradeListId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "Grades",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "GradeList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeListId",
                table: "Students",
                column: "GradeListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_GradeList_GradeListId",
                table: "Grades",
                column: "GradeListId",
                principalTable: "GradeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_GradeList_GradeListId",
                table: "Students",
                column: "GradeListId",
                principalTable: "GradeList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_People_PersonId",
                table: "Students",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_GradeList_GradeListId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_GradeList_GradeListId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_People_PersonId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "GradeList");

            migrationBuilder.DropIndex(
                name: "IX_Students_GradeListId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GradeListId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "GradeListId",
                table: "Grades",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_GradeListId",
                table: "Grades",
                newName: "IX_Grades_StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "Grades",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_People_PersonId",
                table: "Students",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
