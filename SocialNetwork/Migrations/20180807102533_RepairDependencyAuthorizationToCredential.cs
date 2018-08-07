using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class RepairDependencyAuthorizationToCredential : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "IdOwner",
                table: "authorization");

            migrationBuilder.DropForeignKey(
                name: "IdProfile",
                table: "credential");

            migrationBuilder.AddForeignKey(
                name: "FK_authorization_credential_CredentialRef",
                table: "authorization",
                column: "CredentialRef",
                principalTable: "credential",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_credential_profile_ProfileRef",
                table: "credential",
                column: "ProfileRef",
                principalTable: "profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authorization_credential_CredentialRef",
                table: "authorization");

            migrationBuilder.DropForeignKey(
                name: "FK_credential_profile_ProfileRef",
                table: "credential");

            migrationBuilder.AddForeignKey(
                name: "IdOwner",
                table: "authorization",
                column: "CredentialRef",
                principalTable: "credential",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "IdProfile",
                table: "credential",
                column: "ProfileRef",
                principalTable: "profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
