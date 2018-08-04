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
    [Migration("20180804152135_GenderAdd")]
    partial class GenderAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SocialNetwork.Authorizations", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint(20)");

                    b.Property<DateTime?>("DatetimeRequest")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DatetimeStart")
                        .HasColumnType("datetime");

                    b.Property<int>("IdProfile")
                        .HasColumnType("int(11)");

                    b.Property<string>("SystemStatus")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("IdAuthorization_UNIQUE");

                    b.HasIndex("IdProfile")
                        .HasName("IdOwner_idx");

                    b.ToTable("Authorizations");
                });

            modelBuilder.Entity("SocialNetwork.Followers", b =>
                {
                    b.Property<int>("IdProfileSubscriber")
                        .HasColumnType("int(11)");

                    b.Property<int>("IdProfileBloger")
                        .HasColumnType("int(11)");

                    b.HasKey("IdProfileSubscriber", "IdProfileBloger");

                    b.HasIndex("IdProfileBloger")
                        .HasName("idProfileBloger");

                    b.HasIndex("IdProfileSubscriber")
                        .HasName("idProfileSubscriber_idx");

                    b.ToTable("followers");
                });

            modelBuilder.Entity("SocialNetwork.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint(20)");

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("datetime");

                    b.Property<int>("IdProfile")
                        .HasColumnType("int(11)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IdProfile")
                        .HasName("idProfileAuthor_idx");

                    b.ToTable("post");
                });

            modelBuilder.Entity("SocialNetwork.Profile", b =>
                {
                    b.Property<int>("IdProfile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdProfile");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("email_UNIQUE");

                    b.HasIndex("IdProfile")
                        .HasName("idProfile_idx");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("SocialNetwork.Userdata", b =>
                {
                    b.Property<int>("IdProfile");

                    b.Property<int?>("Age")
                        .HasColumnType("int(11)");

                    b.Property<byte?>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Location")
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(8001)");

                    b.HasKey("IdProfile");

                    b.ToTable("Userdata");
                });

            modelBuilder.Entity("SocialNetwork.Authorizations", b =>
                {
                    b.HasOne("SocialNetwork.Profile", "IdProfileNavigation")
                        .WithMany("Authorizations")
                        .HasForeignKey("IdProfile")
                        .HasConstraintName("IdOwner");
                });

            modelBuilder.Entity("SocialNetwork.Followers", b =>
                {
                    b.HasOne("SocialNetwork.Profile", "IdProfileBlogerNavigation")
                        .WithMany("FollowersIdProfileBlogerNavigation")
                        .HasForeignKey("IdProfileBloger")
                        .HasConstraintName("idProfileBloger");

                    b.HasOne("SocialNetwork.Profile", "IdProfileSubscriberNavigation")
                        .WithMany("FollowersIdProfileSubscriberNavigation")
                        .HasForeignKey("IdProfileSubscriber")
                        .HasConstraintName("idProfileSubscriber");
                });

            modelBuilder.Entity("SocialNetwork.Post", b =>
                {
                    b.HasOne("SocialNetwork.Profile", "IdProfileNavigation")
                        .WithMany("Post")
                        .HasForeignKey("IdProfile")
                        .HasConstraintName("idProfileAuthor");
                });

            modelBuilder.Entity("SocialNetwork.Userdata", b =>
                {
                    b.HasOne("SocialNetwork.Profile", "ProfileNavigation")
                        .WithOne("IdUserdataNavigation")
                        .HasForeignKey("SocialNetwork.Userdata", "IdProfile")
                        .HasConstraintName("idProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
