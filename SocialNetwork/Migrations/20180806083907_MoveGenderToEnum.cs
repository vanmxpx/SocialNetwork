using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class MoveGenderToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Gender",
                table: "Userdata",
                nullable: false,
                defaultValue: (byte)2,
                oldClrType: typeof(byte),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Gender",
                table: "Userdata",
                nullable: true,
                oldClrType: typeof(byte),
                oldDefaultValue: (byte)2);
        }
    }
}
