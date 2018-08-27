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

                entity.Property(e => e.SystemStatus)
                    .IsRequired()
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.ToTable("credential");

                // entity.Property(e => e.ProfileRef).HasColumnType("int(11)");

                entity.HasIndex(e => e.Email)
                    .HasName("Email_UNIQUE")
                    .IsUnique();

                // entity.HasIndex(e => e.ProfileRef)
                //     .HasName("ProfileRef_UNIQUE")
                //     .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(64)");

                entity.HasMany(d => d.Authorizations)
                    .WithOne(p => p.Credential)
                    .HasForeignKey(d => d.CredentialRef)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Profile)
                    .WithOne()
                    .HasForeignKey<Profile>(d=> d.CredenitialRef)
                    .OnDelete(DeleteBehavior.Cascade);                 
            });

            modelBuilder.Entity<Followings>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("followings");

                entity.HasIndex(e => e.BloggerRef)
                    .HasName("idBlogger_idx");

                entity.HasIndex(e => e.SubscriberRef)
                    .HasName("idSubscriber_idx");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.HasIndex(e => e.ProfileRef)
                    .HasName("idProfileAuthor_idx");

                entity.Property(e => e.Datetime).HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("profile");

                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.Id)
                    .HasName("idProfile_idx");

                entity.Property(e => e.Gender)
                    .HasColumnType("tinyint(3)")
                    .HasDefaultValueSql("2");

                entity.Property(e => e.LastName)
                  //  .IsRequired()
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Location).HasColumnType("varchar(64)");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Name)
                    //.IsRequired()
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Photo).HasColumnType("varbinary(8001)");
                
                entity.HasMany(d => d.Posts)
                    .WithOne(p => p.Profile)
                    .HasForeignKey(d => d.ProfileRef)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(d => d.Bloggers)
                    .WithOne(p => p.Blogger)
                    .HasForeignKey(d => d.BloggerRef)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(d => d.Subscribers)
                    .WithOne(p => p.Subscriber)
                    .HasForeignKey(d => d.SubscriberRef)
                    .OnDelete(DeleteBehavior.Cascade);

                // entity.OwnsOne(typeof(Credential)).ToTable("credential");  

                // entity.HasMany(d => d.Bloggers)
                //     .WithOne()
                //     .OnDelete(DeleteBehavior.Restrict)
                //     .HasConstraintName("IdBlogger");

                // entity.HasMany(d => d.Subscribers)
                //     .WithOne()
                //     .OnDelete(DeleteBehavior.Restrict)
                //     .HasConstraintName("IdSubscriber");
            });
        }
    }
}
