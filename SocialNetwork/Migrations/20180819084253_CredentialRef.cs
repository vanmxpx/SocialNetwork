using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class CredentialRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_credential_profile_ProfileRef",
                table: "credential");

            migrationBuilder.DropIndex(
                name: "IX_credential_ProfileRef",
                table: "credential");

            migrationBuilder.DropColumn(
                name: "ProfileRef",
                table: "credential");

            migrationBuilder.AddColumn<int>(
                name: "CredenitialRef",
                table: "profile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_profile_CredenitialRef",
                table: "profile",
                column: "CredenitialRef",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_profile_credential_CredenitialRef",
                table: "profile",
                column: "CredenitialRef",
                principalTable: "credential",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profile_credential_CredenitialRef",
                table: "profile");

            migrationBuilder.DropIndex(
                name: "IX_profile_CredenitialRef",
                table: "profile");

            migrationBuilder.DropColumn(
                name: "CredenitialRef",
                table: "profile");

            migrationBuilder.AddColumn<int>(
                name: "ProfileRef",
                table: "credential",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_credential_ProfileRef",
                table: "credential",
                column: "ProfileRef",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_credential_profile_ProfileRef",
                table: "credential",
                column: "ProfileRef",
                principalTable: "profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
