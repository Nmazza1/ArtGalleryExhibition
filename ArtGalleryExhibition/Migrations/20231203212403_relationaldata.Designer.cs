﻿// <auto-generated />
using System;
using ArtGalleryExhibition.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArtGalleryExhibition.Migrations
{
    [DbContext(typeof(ArtGalleryExhibitionContext))]
    [Migration("20231203212403_relationaldata")]
    partial class relationaldata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ArtGalleryExhibition.Models.Artist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ExhibitionID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isFeatured")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("ExhibitionID");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("ArtGalleryExhibition.Models.ArtWork", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ArtistID")
                        .HasColumnType("int");

                    b.Property<string>("CompletionDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExhibitionID")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ArtistID");

                    b.HasIndex("ExhibitionID");

                    b.ToTable("ArtWork");
                });

            modelBuilder.Entity("ArtGalleryExhibition.Models.Exhibition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("currentlyRunning")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Exhibition");
                });

            modelBuilder.Entity("ArtGalleryExhibition.Models.Artist", b =>
                {
                    b.HasOne("ArtGalleryExhibition.Models.Exhibition", null)
                        .WithMany("artists")
                        .HasForeignKey("ExhibitionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArtGalleryExhibition.Models.ArtWork", b =>
                {
                    b.HasOne("ArtGalleryExhibition.Models.Artist", null)
                        .WithMany("ArtWorks")
                        .HasForeignKey("ArtistID");

                    b.HasOne("ArtGalleryExhibition.Models.Exhibition", null)
                        .WithMany("works")
                        .HasForeignKey("ExhibitionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArtGalleryExhibition.Models.Artist", b =>
                {
                    b.Navigation("ArtWorks");
                });

            modelBuilder.Entity("ArtGalleryExhibition.Models.Exhibition", b =>
                {
                    b.Navigation("artists");

                    b.Navigation("works");
                });
#pragma warning restore 612, 618
        }
    }
}
