using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Test.Data.Migrations
{
    public partial class StudentYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentYear",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentYear",
                table: "Students");
        }
    }
}
