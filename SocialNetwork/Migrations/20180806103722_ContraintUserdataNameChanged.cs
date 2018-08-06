using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class ContraintUserdataNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "idProfile",
                table: "Profile");

            migrationBuilder.AddForeignKey(
                name: "idProfileProfile",
                table: "Profile",
                column: "IdProfile",
                principalTable: "Userdata",
                principalColumn: "IdProfile",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "idProfileProfile",
                table: "Profile");

            migrationBuilder.AddForeignKey(
                name: "idProfile",
                table: "Profile",
                column: "IdProfile",
                principalTable: "Userdata",
                principalColumn: "IdProfile",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
