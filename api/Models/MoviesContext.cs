using System;
using api.Database_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Models {
    public partial class MoviesContext : DbContext {
        public MoviesContext () { }

        public MoviesContext (DbContextOptions<MoviesContext> options) : base (options) { }

        public virtual DbSet<StandardMovies> StandardMovies { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<StandardWishlist> StandardWishlist { get; set; }
        public virtual DbSet<StandardUsers> StandardUsers { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer ("Server=localhost;Database=DB_6215_19_S1;User=sa;Password=yourStrong(*)Password;");
            }
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<StandardMovies> (entity => {
                entity.ToTable ("movies");

                entity.Property (e => e.Id).HasColumnName ("ID");

                entity.Property (e => e.Genre)
                    .IsRequired ()
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.Picture)
                    .IsRequired ()
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.Summary)
                    .IsRequired ()
                    .HasMaxLength (500)
                    .IsUnicode (false);

                entity.Property (e => e.Title)
                    .IsRequired ()
                    .HasMaxLength (100)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<StandardUsers> (entity => {
                entity.ToTable ("users");

                entity.Property (e => e.Id).HasColumnName ("ID");

                entity.Property (e => e.Email)
                    .IsRequired ()
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.Fname)
                    .IsRequired ()
                    .HasMaxLength (100)
                    .IsUnicode (false);

                entity.Property (e => e.Lname)
                    .IsRequired ()
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.Passwrd)
                    .IsRequired ()
                    .HasMaxLength (255)
                    .IsUnicode (false);

                entity.Property (e => e.Uname)
                    .IsRequired ()
                    .HasMaxLength (255)
                    .IsUnicode (false);
            });

            modelBuilder.Entity<StandardWishlist> (entity => {
                entity.ToTable ("wishlist");

                entity.Property (e => e.Id).HasColumnName ("ID");
            });
        }
    }
}