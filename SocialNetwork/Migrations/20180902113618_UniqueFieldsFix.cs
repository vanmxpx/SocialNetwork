using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class UniqueFieldsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idProfile_idx",
                table: "profile");

            migrationBuilder.RenameIndex(
                name: "idProfileAuthor_idx",
                table: "post",
                newName: "profileRef_idx");

            migrationBuilder.RenameIndex(
                name: "Id_UNIQUE",
                table: "authorization",
                newName: "IdAuthorization_idx");

            migrationBuilder.CreateIndex(
                name: "idProfile_idx",
                table: "profile",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "login_idx",
                table: "profile",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idPost_idx",
                table: "post",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE",
                table: "followings",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE",
                table: "credential",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idProfile_idx",
                table: "profile");

            migrationBuilder.DropIndex(
                name: "login_idx",
                table: "profile");

            migrationBuilder.DropIndex(
                name: "idPost_idx",
                table: "post");

            migrationBuilder.DropIndex(
                name: "Id_UNIQUE",
                table: "followings");

            migrationBuilder.DropIndex(
                name: "Id_UNIQUE",
                table: "credential");

            migrationBuilder.RenameIndex(
                name: "profileRef_idx",
                table: "post",
                newName: "idProfileAuthor_idx");

            migrationBuilder.RenameIndex(
                name: "IdAuthorization_idx",
                table: "authorization",
                newName: "Id_UNIQUE");

            migrationBuilder.CreateIndex(
                name: "idProfile_idx",
                table: "profile",
                column: "Id");
        }
    }
}
