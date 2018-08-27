﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork;

namespace SocialNetwork.Migrations
{
    [DbContext(typeof(ShortyContext))]
    [Migration("20180818173354_ProfileNonRequiredNameAndLastName")]
    partial class ProfileNonRequiredNameAndLastName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SocialNetwork.Authorization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CredentialRef");

                    b.Property<DateTime>("DatetimeRequest");

                    b.Property<DateTime>("DatetimeStart");

                    b.Property<string>("SystemStatus")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id");

                    b.HasIndex("CredentialRef")
                        .HasName("IdCredential_idx");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("Id_UNIQUE");

                    b.ToTable("authorization");
                });

            modelBuilder.Entity("SocialNetwork.Credential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateRegistration");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<int>("ProfileRef")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("Email_UNIQUE");

                    b.HasIndex("ProfileRef")
                        .IsUnique()
                        .HasName("ProfileRef_UNIQUE");

                    b.ToTable("credential");
                });

            modelBuilder.Entity("SocialNetwork.Followings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BloggerRef");

                    b.Property<int>("SubscriberRef");

                    b.HasKey("Id");

                    b.HasIndex("BloggerRef")
                        .HasName("idBlogger_idx");

                    b.HasIndex("SubscriberRef")
                        .HasName("idSubscriber_idx");

                    b.ToTable("followings");
                });

            modelBuilder.Entity("SocialNetwork.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("datetime");

                    b.Property<int>("ProfileRef");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ProfileRef")
                        .HasName("idProfileAuthor_idx");

                    b.ToTable("post");
                });

            modelBuilder.Entity("SocialNetwork.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte?>("Age");

                    b.Property<sbyte>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(3)")
                        .HasDefaultValueSql("2");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Location")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(32)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(8001)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasName("idProfile_idx");

                    b.ToTable("profile");
                });

            modelBuilder.Entity("SocialNetwork.Authorization", b =>
                {
                    b.HasOne("SocialNetwork.Credential", "Credential")
                        .WithMany("Authorizations")
                        .HasForeignKey("CredentialRef")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SocialNetwork.Credential", b =>
                {
                    b.HasOne("SocialNetwork.Profile", "Profile")
                        .WithOne()
                        .HasForeignKey("SocialNetwork.Credential", "ProfileRef")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SocialNetwork.Followings", b =>
                {
                    b.HasOne("SocialNetwork.Profile", "Blogger")
                        .WithMany("Bloggers")
                        .HasForeignKey("BloggerRef")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SocialNetwork.Profile", "Subscriber")
                        .WithMany("Subscribers")
                        .HasForeignKey("SubscriberRef")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SocialNetwork.Post", b =>
                {
                    b.HasOne("SocialNetwork.Profile", "Profile")
                        .WithMany("Posts")
                        .HasForeignKey("ProfileRef")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}