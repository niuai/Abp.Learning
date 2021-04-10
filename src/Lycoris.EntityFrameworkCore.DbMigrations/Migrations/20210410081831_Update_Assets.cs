using Microsoft.EntityFrameworkCore.Migrations;

namespace Lycoris.Migrations
{
    public partial class Update_Assets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AppAssets",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppAssets",
                type: "varchar(40) CHARACTER SET utf8mb4",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AppAssets",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppAssets",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40) CHARACTER SET utf8mb4",
                oldMaxLength: 40,
                oldNullable: true);
        }
    }
}
