using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class AuthFieldNameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authorization_credential_CredentialId",
                table: "authorization");

            migrationBuilder.DropIndex(
                name: "IX_authorization_CredentialId",
                table: "authorization");

            migrationBuilder.DropColumn(
                name: "CredentialId",
                table: "authorization");

            migrationBuilder.AddForeignKey(
                name: "FK_authorization_credential_CredentialRef",
                table: "authorization",
                column: "CredentialRef",
                principalTable: "credential",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authorization_credential_CredentialRef",
                table: "authorization");

            migrationBuilder.AddColumn<int>(
                name: "CredentialId",
                table: "authorization",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_authorization_CredentialId",
                table: "authorization",
                column: "CredentialId");

            migrationBuilder.AddForeignKey(
                name: "FK_authorization_credential_CredentialId",
                table: "authorization",
                column: "CredentialId",
                principalTable: "credential",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
