using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace McWorld.Shared.QueryStack
{
    public partial class QueryContext : DbContext
    {
        public QueryContext()
        {
        }

        public QueryContext(DbContextOptions<QueryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Routes> Routes { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=McWorldDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.RouteId);

                entity.Property(e => e.AddressId).ValueGeneratedNever();

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.Property(e => e.StreetName).IsRequired();

                entity.Property(e => e.StreetNumber).IsRequired();

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.RouteId);
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.HasIndex(e => e.RouteId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.EventId)
                    .HasColumnName("EventID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EndDate).IsRequired();

                entity.Property(e => e.EndTime).IsRequired();

                entity.Property(e => e.Headline).IsRequired();

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.Property(e => e.StartDate).IsRequired();

                entity.Property(e => e.StartTime).IsRequired();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.RouteId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.EventId });

                entity.HasIndex(e => e.EventId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.EventId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Routes>(entity =>
            {
                entity.HasKey(e => e.RouteId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.RouteId)
                    .HasColumnName("RouteID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Created).IsRequired();

                entity.Property(e => e.Distance).IsRequired();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Birthdate).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username).IsRequired();
            });
        }
    }
}
