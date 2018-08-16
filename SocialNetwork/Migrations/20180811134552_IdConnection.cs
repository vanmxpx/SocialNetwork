using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class IdConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_followers_profile_BloggerRef",
                table: "followers");

            migrationBuilder.DropForeignKey(
                name: "FK_followers_profile_SubscriberRef",
                table: "followers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_followers",
                table: "followers");

            migrationBuilder.RenameTable(
                name: "followers",
                newName: "followings");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "followings",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_followings",
                table: "followings",
                column: "Id");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_followings_profile_BloggerRef",
                table: "followings");

            migrationBuilder.DropForeignKey(
                name: "FK_followings_profile_SubscriberRef",
                table: "followings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_followings",
                table: "followings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "followings");

            migrationBuilder.RenameTable(
                name: "followings",
                newName: "followers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_followers",
                table: "followers",
                columns: new[] { "SubscriberRef", "BloggerRef" });

            migrationBuilder.AddForeignKey(
                name: "FK_followers_profile_BloggerRef",
                table: "followers",
                column: "BloggerRef",
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
        }
    }
}
