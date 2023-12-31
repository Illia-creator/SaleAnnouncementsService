﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SaleAnnouncementsService.Infrastructure.DbContexts;

#nullable disable

namespace SaleAnnouncementsService.Infrastructure.Migrations
{
    [DbContext(typeof(SaleAnnouncementsServiceDbContext))]
    partial class SaleAnnouncementsServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SaleAnnouncementsService.Domain.Entities.Announcement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("SaleAnnouncementsService.Domain.Entities.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AnnoncementId")
                        .HasColumnType("uuid");

                    b.Property<string>("MainPhotoLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecondPhotoLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ThirdPhotoLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnnoncementId")
                        .IsUnique();

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("SaleAnnouncementsService.Domain.Entities.Photo", b =>
                {
                    b.HasOne("SaleAnnouncementsService.Domain.Entities.Announcement", "Annoncement")
                        .WithOne("Photo")
                        .HasForeignKey("SaleAnnouncementsService.Domain.Entities.Photo", "AnnoncementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Annoncement");
                });

            modelBuilder.Entity("SaleAnnouncementsService.Domain.Entities.Announcement", b =>
                {
                    b.Navigation("Photo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
