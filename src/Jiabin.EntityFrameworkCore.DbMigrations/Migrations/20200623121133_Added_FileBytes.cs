using Microsoft.EntityFrameworkCore.Migrations;

namespace Jiabin.Migrations
{
    public partial class Added_FileBytes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileBytes",
                table: "AppAssets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "AppAssets");
        }
    }
}
