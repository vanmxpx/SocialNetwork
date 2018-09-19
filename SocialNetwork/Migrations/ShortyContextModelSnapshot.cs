﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork;

namespace SocialNetwork.Migrations
{
    [DbContext(typeof(ShortyContext))]
    partial class ShortyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasName("IdAuthorization_idx");

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

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("Email_UNIQUE");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("Id_UNIQUE");

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

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("Id_UNIQUE");

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

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("idPost_idx");

                    b.HasIndex("ProfileRef")
                        .HasName("profileRef_idx");

                    b.ToTable("post");
                });

            modelBuilder.Entity("SocialNetwork.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte?>("Age");

                    b.Property<int>("CredenitialRef");

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

                    b.HasIndex("CredenitialRef")
                        .IsUnique();

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("idProfile_idx");

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasName("login_idx");

                    b.ToTable("profile");
                });

            modelBuilder.Entity("SocialNetwork.Authorization", b =>
                {
                    b.HasOne("SocialNetwork.Credential", "Credential")
                        .WithMany("Authorizations")
                        .HasForeignKey("CredentialRef")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SocialNetwork.Followings", b =>
                {
                    b.HasOne("SocialNetwork.Profile", "Blogger")
                        .WithMany("Bloggers")
                        .HasForeignKey("BloggerRef")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SocialNetwork.Profile", "Subscriber")
                        .WithMany("Subscribers")
                        .HasForeignKey("SubscriberRef")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SocialNetwork.Post", b =>
                {
                    b.HasOne("SocialNetwork.Profile", "Profile")
                        .WithMany("Posts")
                        .HasForeignKey("ProfileRef")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SocialNetwork.Profile", b =>
                {
                    b.HasOne("SocialNetwork.Credential")
                        .WithOne("Profile")
                        .HasForeignKey("SocialNetwork.Profile", "CredenitialRef")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
