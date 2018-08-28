using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class ProfileCascadeDeletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_followings_profile_BloggerRef",
                table: "followings");

            migrationBuilder.DropForeignKey(
                name: "FK_followings_profile_SubscriberRef",
                table: "followings");

            migrationBuilder.DropForeignKey(
                name: "FK_post_profile_ProfileRef",
                table: "post");

            migrationBuilder.AddForeignKey(
                name: "FK_followings_profile_BloggerRef",
                table: "followings",
                column: "BloggerRef",
                principalTable: "profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_followings_profile_SubscriberRef",
                table: "followings",
                column: "SubscriberRef",
                principalTable: "profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_profile_ProfileRef",
                table: "post",
                column: "ProfileRef",
                principalTable: "profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_followings_profile_BloggerRef",
                table: "followings");

            migrationBuilder.DropForeignKey(
                name: "FK_followings_profile_SubscriberRef",
                table: "followings");

            migrationBuilder.DropForeignKey(
                name: "FK_post_profile_ProfileRef",
                table: "post");

            migrationBuilder.AddForeignKey(
                name: "FK_followings_profile_BloggerRef",
                table: "followings",
                column: "BloggerRef",
                principalTable: "profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_followings_profile_SubscriberRef",
                table: "followings",
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
    }
}
