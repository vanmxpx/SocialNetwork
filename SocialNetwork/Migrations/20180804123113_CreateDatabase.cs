using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    IdProfile = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(45)", nullable: false),
                    Password = table.Column<string>(type: "varchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.IdProfile);
                });

            migrationBuilder.CreateTable(
                name: "Authorizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProfile = table.Column<int>(type: "int(11)", nullable: false),
                    SystemStatus = table.Column<string>(type: "varchar(45)", nullable: false),
                    DatetimeStart = table.Column<DateTime>(type: "datetime", nullable: true),
                    DatetimeRequest = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorizations", x => x.Id);
                    table.ForeignKey(
                        name: "IdOwner",
                        column: x => x.IdProfile,
                        principalTable: "Profile",
                        principalColumn: "IdProfile",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "followers",
                columns: table => new
                {
                    IdProfileBloger = table.Column<int>(type: "int(11)", nullable: false),
                    IdProfileSubscriber = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_followers", x => new { x.IdProfileSubscriber, x.IdProfileBloger });
                    table.ForeignKey(
                        name: "idProfileBloger",
                        column: x => x.IdProfileBloger,
                        principalTable: "Profile",
                        principalColumn: "IdProfile",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "idProfileSubscriber",
                        column: x => x.IdProfileSubscriber,
                        principalTable: "Profile",
                        principalColumn: "IdProfile",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProfile = table.Column<int>(type: "int(11)", nullable: false),
                    Text = table.Column<string>(type: "varchar(256)", nullable: false),
                    Datetime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.Id);
                    table.ForeignKey(
                        name: "idProfileAuthor",
                        column: x => x.IdProfile,
                        principalTable: "Profile",
                        principalColumn: "IdProfile",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Userdata",
                columns: table => new
                {
                    IdProfile = table.Column<int>(nullable: false),
                    Login = table.Column<string>(type: "varchar(40)", nullable: false),
                    Name = table.Column<string>(type: "varchar(45)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(45)", nullable: false),
                    Location = table.Column<string>(type: "varchar(45)", nullable: true),
                    Age = table.Column<int>(type: "int(11)", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(8001)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userdata", x => x.IdProfile);
                    table.ForeignKey(
                        name: "idProfile",
                        column: x => x.IdProfile,
                        principalTable: "Profile",
                        principalColumn: "IdProfile",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IdAuthorization_UNIQUE",
                table: "Authorizations",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IdOwner_idx",
                table: "Authorizations",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "idProfileBloger",
                table: "followers",
                column: "IdProfileBloger");

            migrationBuilder.CreateIndex(
                name: "idProfileSubscriber_idx",
                table: "followers",
                column: "IdProfileSubscriber");

            migrationBuilder.CreateIndex(
                name: "idProfileAuthor_idx",
                table: "post",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "email_UNIQUE",
                table: "Profile",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idProfile_idx",
                table: "Profile",
                column: "IdProfile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authorizations");

            migrationBuilder.DropTable(
                name: "followers");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "Userdata");

            migrationBuilder.DropTable(
                name: "Profile");
        }
    }
}
