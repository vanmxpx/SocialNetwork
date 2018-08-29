using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class CascadeDeletionInCredentials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authorization_credential_CredentialRef",
                table: "authorization");

            migrationBuilder.DropForeignKey(
                name: "FK_profile_credential_CredenitialRef",
                table: "profile");

            migrationBuilder.AddForeignKey(
                name: "FK_authorization_credential_CredentialRef",
                table: "authorization",
                column: "CredentialRef",
                principalTable: "credential",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_profile_credential_CredenitialRef",
                table: "profile",
                column: "CredenitialRef",
                principalTable: "credential",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authorization_credential_CredentialRef",
                table: "authorization");

            migrationBuilder.DropForeignKey(
                name: "FK_profile_credential_CredenitialRef",
                table: "profile");

            migrationBuilder.AddForeignKey(
                name: "FK_authorization_credential_CredentialRef",
                table: "authorization",
                column: "CredentialRef",
                principalTable: "credential",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_profile_credential_CredenitialRef",
                table: "profile",
                column: "CredenitialRef",
                principalTable: "credential",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
