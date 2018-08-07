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
                name: "profile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(type: "varchar(32)", nullable: false),
                    Name = table.Column<string>(type: "varchar(32)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(32)", nullable: false),
                    Gender = table.Column<sbyte>(type: "tinyint(3)", nullable: false, defaultValueSql: "2"),
                    Location = table.Column<string>(type: "varchar(64)", nullable: true),
                    Age = table.Column<byte>(nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(8001)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "credential",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(64)", nullable: false),
                    Password = table.Column<string>(type: "varchar(64)", nullable: false),
                    DateRegistration = table.Column<DateTime>(nullable: false),
                    ProfileRef = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credential", x => x.Id);
                    table.ForeignKey(
                        name: "IdProfile",
                        column: x => x.ProfileRef,
                        principalTable: "profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "followers",
                columns: table => new
                {
                    BlogerRef = table.Column<int>(nullable: false),
                    SubscriberRef = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_followers", x => new { x.SubscriberRef, x.BlogerRef });
                    table.ForeignKey(
                        name: "BlogerRef",
                        column: x => x.BlogerRef,
                        principalTable: "profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "SubscriberRef",
                        column: x => x.SubscriberRef,
                        principalTable: "profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "varchar(256)", nullable: false),
                    Datetime = table.Column<DateTime>(nullable: false),
                    ProfileRef = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.Id);
                    table.ForeignKey(
                        name: "IdAuthor",
                        column: x => x.ProfileRef,
                        principalTable: "profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "authorization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SystemStatus = table.Column<string>(type: "varchar(45)", nullable: false),
                    DatetimeStart = table.Column<DateTime>(nullable: false),
                    DatetimeRequest = table.Column<DateTime>(nullable: false),
                    CredentialRef = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authorization", x => x.Id);
                    table.ForeignKey(
                        name: "IdOwner",
                        column: x => x.CredentialRef,
                        principalTable: "credential",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IdCredential_idx",
                table: "authorization",
                column: "CredentialRef");

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE",
                table: "authorization",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Email_UNIQUE",
                table: "credential",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ProfileRef_UNIQUE",
                table: "credential",
                column: "ProfileRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idBloger_idx",
                table: "followers",
                column: "BlogerRef");

            migrationBuilder.CreateIndex(
                name: "idSubscriber_idx",
                table: "followers",
                column: "SubscriberRef");

            migrationBuilder.CreateIndex(
                name: "idProfileAuthor_idx",
                table: "post",
                column: "ProfileRef");

            migrationBuilder.CreateIndex(
                name: "idProfile_idx",
                table: "profile",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authorization");

            migrationBuilder.DropTable(
                name: "followers");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "credential");

            migrationBuilder.DropTable(
                name: "profile");
        }
    }
}
