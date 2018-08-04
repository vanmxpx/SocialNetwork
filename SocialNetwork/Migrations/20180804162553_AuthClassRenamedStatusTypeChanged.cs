using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class AuthClassRenamedStatusTypeChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Userdata",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(byte),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SystemStatus",
                table: "Authorizations",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(45)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Gender",
                table: "Userdata",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SystemStatus",
                table: "Authorizations",
                type: "varchar(45)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)");
        }
    }
}
