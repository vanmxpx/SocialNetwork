using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class DeleteProfileRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "ProfileRef_UNIQUE",
                table: "credential",
                newName: "IX_credential_ProfileRef");

            migrationBuilder.AddColumn<int>(
                name: "CredenitialRef",
                table: "profile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProfileRef",
                table: "credential",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CredenitialRef",
                table: "profile");

            migrationBuilder.RenameIndex(
                name: "IX_credential_ProfileRef",
                table: "credential",
                newName: "ProfileRef_UNIQUE");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileRef",
                table: "credential",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
