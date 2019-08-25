﻿// <auto-generated />
using System;
using MCAPI.McContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MCAPI.Migrations
{
    [DbContext(typeof(McDbContext))]
    partial class McDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MCAPI.Models.Adresse", b =>
                {
                    b.Property<int>("AdresseID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<string>("StreetName");

                    b.Property<double>("StreetNumber");

                    b.Property<int>("Zipcode");

                    b.HasKey("AdresseID");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("MCAPI.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Created");

                    b.Property<string>("Description");

                    b.Property<string>("EndDate");

                    b.Property<string>("EndTime");

                    b.Property<string>("Headline");

                    b.Property<int>("RegistrationCount");

                    b.Property<int?>("RouteID");

                    b.Property<string>("StartDate");

                    b.Property<string>("StartTime");

                    b.Property<int?>("UserID");

                    b.HasKey("EventID");

                    b.HasIndex("RouteID");

                    b.HasIndex("UserID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("MCAPI.Models.Registration", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<int>("EventID");

                    b.HasKey("UserID", "EventID");

                    b.HasIndex("EventID");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("MCAPI.Models.Route", b =>
                {
                    b.Property<int>("RouteID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdresseID");

                    b.Property<string>("Created");

                    b.Property<double>("Distance");

                    b.Property<bool>("Ferry");

                    b.Property<bool>("Motorway");

                    b.Property<bool>("Toll");

                    b.Property<int?>("UserID");

                    b.HasKey("RouteID");

                    b.HasIndex("AdresseID");

                    b.HasIndex("UserID");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("MCAPI.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Birthdate");

                    b.Property<string>("Created")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MCAPI.Models.Event", b =>
                {
                    b.HasOne("MCAPI.Models.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteID");

                    b.HasOne("MCAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("MCAPI.Models.Registration", b =>
                {
                    b.HasOne("MCAPI.Models.Event", "Event")
                        .WithMany("Registration")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MCAPI.Models.User", "User")
                        .WithMany("Registration")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MCAPI.Models.Route", b =>
                {
                    b.HasOne("MCAPI.Models.Adresse", "Adresse")
                        .WithMany()
                        .HasForeignKey("AdresseID");

                    b.HasOne("MCAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
