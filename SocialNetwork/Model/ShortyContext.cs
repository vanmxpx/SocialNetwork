using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SocialNetwork
{
    public partial class ShortyContext : DbContext
    {
        public ShortyContext()
        {
        }

        public ShortyContext(DbContextOptions<ShortyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authorization> Authorizations { get; set; }
        public virtual DbSet<Followers> Followers { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Userdata> Userdata { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySql("Server=localhost;Database=shorty;User=root;Password=qwertyui;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authorization>(entity =>
            {
                entity.ToTable("Authorizations");

                entity.HasIndex(e => e.Id)
                    .HasName("IdAuthorization_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdProfile)
                    .HasName("IdOwner_idx");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.DatetimeRequest).HasColumnType("datetime");

                entity.Property(e => e.DatetimeStart).HasColumnType("datetime");

                entity.Property(e => e.IdProfile).HasColumnType("int(11)");

                entity.Property(e => e.SystemStatus)
                    .IsRequired()
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdProfileNavigation)
                    .WithMany(p => p.Authorizations)
                    .HasForeignKey(d => d.IdProfile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdOwner");
            });

            modelBuilder.Entity<Followers>(entity =>
            {
                entity.ToTable("followers");

                entity.HasKey(e => new { e.IdProfileSubscriber, e.IdProfileBloger });

                entity.HasIndex(e => e.IdProfileBloger)
                    .HasName("idProfileBloger");

                entity.HasIndex(e => e.IdProfileSubscriber)
                    .HasName("idProfileSubscriber_idx");

                entity.Property(e => e.IdProfileBloger).HasColumnType("int(11)");

                entity.Property(e => e.IdProfileSubscriber).HasColumnType("int(11)");

                entity.HasOne(d => d.IdProfileBlogerNavigation)
                    .WithMany(p => p.FollowersIdProfileBlogerNavigation)
                    .HasForeignKey(d => d.IdProfileBloger)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idProfileBloger");

                entity.HasOne(d => d.IdProfileSubscriberNavigation)
                    .WithMany(p => p.FollowersIdProfileSubscriberNavigation)
                    .HasForeignKey(d => d.IdProfileSubscriber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idProfileSubscriber");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");

                entity.HasIndex(e => e.IdProfile)
                    .HasName("idProfileAuthor_idx");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.Datetime).HasColumnType("datetime");

                entity.Property(e => e.IdProfile).HasColumnType("int(11)");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("varchar(256)");

                entity.HasOne(d => d.IdProfileNavigation)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.IdProfile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idProfileAuthor");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.IdProfile);

                entity.ToTable("Profile");

                entity.HasIndex(e => e.IdProfile)
                    .HasName("idProfile_idx");

                entity.Property(e => e.IdProfile).HasColumnType("int(11)");

                entity.HasIndex(e => e.Email)
    .HasName("email_UNIQUE")
    .IsUnique();

                entity.Property(e => e.IdProfile)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.DateRegistration)
                .IsRequired()
                .HasColumnType("datetime");
            });

            modelBuilder.Entity<Userdata>(entity =>
            {
                entity.HasKey(e => e.IdProfile);

                entity.ToTable("Userdata");

                entity.Property(e => e.Age).HasColumnType("int(11)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Location).HasColumnType("varchar(45)");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Photo).HasColumnType("varbinary(8001)");

                entity.Property(e => e.Gender).HasColumnType("int(11)");

                entity.HasOne(d => d.ProfileNavigation)
                    .WithOne(p => p.UserdataNavigation)
                    .HasForeignKey<Userdata>(d => d.IdProfile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idProfile");
            });
        }
    }
}
