using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SocialNetwork
{
    public class ShortyContext : DbContext
    {
        public ShortyContext(DbContextOptions<ShortyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authorization> Authorization { get; set; }
        public virtual DbSet<Credential> Credential { get; set; }
        public virtual DbSet<Followings> Followers { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authorization>(entity =>
            {
                entity.ToTable("authorization");

                entity.HasIndex(e => e.CredentialRef)
                    .HasName("IdCredential_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CredentialRef).HasColumnType("int(11)");

                entity.Property(e => e.DatetimeRequest).HasColumnType("datetime");

                entity.Property(e => e.DatetimeStart).HasColumnType("datetime");

                entity.Property(e => e.SystemStatus)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Credential)
                    .WithMany(p => p.Authorizations)
                    .HasForeignKey(d => d.CredentialRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdOwner");
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.ToTable("credential");

                entity.HasIndex(e => e.Email)
                    .HasName("Email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.ProfileRef)
                    .HasName("ProfileRef_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DateRegistration).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.ProfileRef).HasColumnType("int(11)");

                entity.HasOne(d => d.Profile)
                    .WithOne()
                    .HasForeignKey<Credential>(d => d.ProfileRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdProfile");
            });

            modelBuilder.Entity<Followings>(entity =>
            {
                entity.HasKey(e => new { e.SubscriberRef, e.BlogerRef });

                entity.ToTable("followers");

                entity.HasIndex(e => e.BlogerRef)
                    .HasName("idBloger_idx");

                entity.HasIndex(e => e.SubscriberRef)
                    .HasName("idSubscriber_idx");

                entity.Property(e => e.BlogerRef).HasColumnType("int(11)");

                entity.Property(e => e.SubscriberRef).HasColumnType("int(11)");

                entity.HasOne(d => d.Bloger)
                    .WithMany(p => p.Blogers)
                    .HasForeignKey(d => d.BlogerRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdBloger");

                entity.HasOne(d => d.Subscriber)
                    .WithMany(p => p.Subscribers)
                    .HasForeignKey(d => d.SubscriberRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdSubscriber");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.HasIndex(e => e.ProfileRef)
                    .HasName("idProfileAuthor_idx");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.Datetime).HasColumnType("datetime");

                entity.Property(e => e.ProfileRef).HasColumnType("int(11)");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("varchar(256)");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.ProfileRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdAuthor");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profile");

                entity.HasIndex(e => e.Id)
                    .HasName("idProfile_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Age).HasColumnType("tinyint(3)");

                entity.Property(e => e.Gender)
                    .HasColumnType("tinyint(3)")
                    .HasDefaultValueSql("2");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Location).HasColumnType("varchar(64)");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Photo).HasColumnType("varbinary(8001)");
            });
        }
    }
}
