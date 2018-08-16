using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class BloggersNameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authorization_credential_CredentialRef",
                table: "authorization");

            migrationBuilder.DropForeignKey(
                name: "FK_followers_profile_BlogerRef",
                table: "followers");

            migrationBuilder.RenameColumn(
                name: "BlogerRef",
                table: "followers",
                newName: "BloggerRef");

            migrationBuilder.RenameIndex(
                name: "idBloger_idx",
                table: "followers",
                newName: "idBlogger_idx");

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

            migrationBuilder.AddForeignKey(
                name: "FK_followers_profile_BloggerRef",
                table: "followers",
                column: "BloggerRef",
                principalTable: "profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_authorization_credential_CredentialId",
                table: "authorization");

            migrationBuilder.DropForeignKey(
                name: "FK_followers_profile_BloggerRef",
                table: "followers");

            migrationBuilder.DropIndex(
                name: "IX_authorization_CredentialId",
                table: "authorization");

            migrationBuilder.DropColumn(
                name: "CredentialId",
                table: "authorization");

            migrationBuilder.RenameColumn(
                name: "BloggerRef",
                table: "followers",
                newName: "BlogerRef");

            migrationBuilder.RenameIndex(
                name: "idBlogger_idx",
                table: "followers",
                newName: "idBloger_idx");

            migrationBuilder.AddForeignKey(
                name: "FK_authorization_credential_CredentialRef",
                table: "authorization",
                column: "CredentialRef",
                principalTable: "credential",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_followers_profile_BlogerRef",
                table: "followers",
                column: "BlogerRef",
                principalTable: "profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
