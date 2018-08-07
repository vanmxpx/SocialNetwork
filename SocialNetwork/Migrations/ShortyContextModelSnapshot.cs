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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("CredentialRef")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("DatetimeRequest")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DatetimeStart")
                        .HasColumnType("datetime");

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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime");

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
                    b.Property<int>("SubscriberRef")
                        .HasColumnType("int(11)");

                    b.Property<int>("BlogerRef")
                        .HasColumnType("int(11)");

                    b.HasKey("SubscriberRef", "BlogerRef");

                    b.HasIndex("BlogerRef")
                        .HasName("idBloger_idx");

                    b.HasIndex("SubscriberRef")
                        .HasName("idSubscriber_idx");

                    b.ToTable("followers");
                });

            modelBuilder.Entity("SocialNetwork.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint(20)");

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("datetime");

                    b.Property<int>("ProfileRef")
                        .HasColumnType("int(11)");

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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<sbyte?>("Age")
                        .HasColumnType("tinyint(3)");

                    b.Property<sbyte>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(3)")
                        .HasDefaultValueSql("2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Location")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Name")
                        .IsRequired()
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
                        .HasConstraintName("IdOwner");
                });

            modelBuilder.Entity("SocialNetwork.Credential", b =>
                {
                    b.HasOne("SocialNetwork.Profile", "Profile")
                        .WithOne()
                        .HasForeignKey("SocialNetwork.Credential", "ProfileRef")
                        .HasConstraintName("IdProfile");
                });

            modelBuilder.Entity("SocialNetwork.Followings", b =>
                {
                    b.HasOne("SocialNetwork.Profile", "Bloger")
                        .WithMany("Blogers")
                        .HasForeignKey("BlogerRef")
                        .HasConstraintName("IdBloger");

                    b.HasOne("SocialNetwork.Profile", "Subscriber")
                        .WithMany("Subscribers")
                        .HasForeignKey("SubscriberRef")
                        .HasConstraintName("IdSubscriber");
                });

            modelBuilder.Entity("SocialNetwork.Post", b =>
                {
                    b.HasOne("SocialNetwork.Profile", "Profile")
                        .WithMany("Posts")
                        .HasForeignKey("ProfileRef")
                        .HasConstraintName("IdAuthor");
                });
#pragma warning restore 612, 618
        }
    }
}
