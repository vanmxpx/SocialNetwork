using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class RenameFollowersToFollowings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdBloger",
                table: "followers",
                newName: "BlogerRef");

            migrationBuilder.RenameColumn(
                name: "IdSubscriber",
                table: "followers",
                newName: "SubscriberRef");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogerRef",
                table: "followers",
                newName: "IdBloger");

            migrationBuilder.RenameColumn(
                name: "SubscriberRef",
                table: "followers",
                newName: "IdSubscriber");
        }
    }
}
