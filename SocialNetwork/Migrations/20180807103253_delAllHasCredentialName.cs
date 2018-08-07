using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class delAllHasCredentialName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "IdBloger",
                table: "followers");

            migrationBuilder.DropForeignKey(
                name: "IdSubscriber",
                table: "followers");

            migrationBuilder.DropForeignKey(
                name: "IdAuthor",
                table: "post");

            migrationBuilder.AddForeignKey(
                name: "FK_followers_profile_BlogerRef",
                table: "followers",
                column: "BlogerRef",
                principalTable: "profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_followers_profile_SubscriberRef",
                table: "followers",
                column: "SubscriberRef",
                principalTable: "profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_post_profile_ProfileRef",
                table: "post",
                column: "ProfileRef",
                principalTable: "profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_followers_profile_BlogerRef",
                table: "followers");

            migrationBuilder.DropForeignKey(
                name: "FK_followers_profile_SubscriberRef",
                table: "followers");

            migrationBuilder.DropForeignKey(
                name: "FK_post_profile_ProfileRef",
                table: "post");

            migrationBuilder.AddForeignKey(
                name: "IdBloger",
                table: "followers",
                column: "BlogerRef",
                principalTable: "profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "IdSubscriber",
                table: "followers",
                column: "SubscriberRef",
                principalTable: "profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "IdAuthor",
                table: "post",
                column: "ProfileRef",
                principalTable: "profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
