using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class GenderFixEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "Gender",
                table: "profile",
                type: "tinyint(3)",
                nullable: false,
                defaultValueSql: "2",
                oldClrType: typeof(sbyte),
                oldType: "tinyint(3)",
                oldDefaultValueSql: "'2'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "Gender",
                table: "profile",
                type: "tinyint(3)",
                nullable: false,
                defaultValueSql: "'2'",
                oldClrType: typeof(sbyte),
                oldType: "tinyint(3)",
                oldDefaultValueSql: "2");
        }
    }
}
