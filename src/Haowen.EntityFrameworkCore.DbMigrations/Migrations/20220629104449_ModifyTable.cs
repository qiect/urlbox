using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Haowen.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class ModifyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Articles",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Articles",
                newName: "Title");
        }
    }
}
