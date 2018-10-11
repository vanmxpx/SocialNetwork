using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class PhotoDefaultPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "profile");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "profile",
                type: "varchar(64)",
                nullable: true,
                defaultValue: "./assets/avatars/avatar.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "profile");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "profile",
                type: "varbinary(8001)",
                nullable: true);
        }
    }
}
