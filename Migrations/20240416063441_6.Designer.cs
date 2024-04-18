﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Save__plan_your_trips.Data;

#nullable disable

namespace Save__plan_your_trips.Migrations
{
    [DbContext(typeof(ScheduleTripsDbContext))]
    [Migration("20240416063441_6")]
    partial class _6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Save__plan_your_trips.Models.Domain.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Save__plan_your_trips.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Save__plan_your_trips.Models.Domain.ScheduledTrip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fifth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fourth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Second")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Third")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ScheduledTrip");
                });

            modelBuilder.Entity("Save__plan_your_trips.Models.Domain.Image", b =>
                {
                    b.HasOne("Save__plan_your_trips.Models.Domain.Album", "Album")
                        .WithMany("Images")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Save__plan_your_trips.Models.Domain.Album", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}