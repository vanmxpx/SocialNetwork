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

        public virtual DbSet<Authorization> Authorizations { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<Followings> Followers { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }

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

                entity.Property(e => e.SystemStatus)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.ToTable("credential");

                entity.Property(e => e.ProfileRef).HasColumnType("int(11)");

                entity.HasIndex(e => e.Email)
                    .HasName("Email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.ProfileRef)
                    .HasName("ProfileRef_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(64)");

                entity.HasOne(d => d.Profile)
                    .WithOne()
                    .HasForeignKey<Credential>(d => d.ProfileRef)
                    .OnDelete(DeleteBehavior.Restrict);

                    entity.HasMany(d => d.Authorizations)
                    .WithOne(p=>p.Credential)
                    .HasForeignKey(p=>p.CredentialRef)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Followings>(entity =>
            {
                entity.HasKey(e => new { e.SubscriberRef, e.BlogerRef });

                entity.ToTable("followers");

                entity.HasIndex(e => e.BlogerRef)
                    .HasName("idBloger_idx");

                entity.HasIndex(e => e.SubscriberRef)
                    .HasName("idSubscriber_idx");

                entity.HasOne(d => d.Bloger)
                    .WithMany(p => p.Blogers)
                    .HasForeignKey(d => d.BlogerRef)
                    .OnDelete(DeleteBehavior.Restrict);


                entity.HasOne(d => d.Subscriber)
                    .WithMany(p => p.Subscribers)
                    .HasForeignKey(d => d.SubscriberRef)
                    .OnDelete(DeleteBehavior.Restrict);

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
                    .OnDelete(DeleteBehavior.Restrict);
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
