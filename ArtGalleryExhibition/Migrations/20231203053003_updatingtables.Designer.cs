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
    [Migration("20231203053003_updatingtables")]
    partial class updatingtables
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ExhibitionId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isFeatured")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ExhibitionId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("ArtGalleryExhibition.Models.ArtWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("CompletionDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExhibitionId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("ExhibitionId");

                    b.ToTable("ArtWork");
                });

            modelBuilder.Entity("ArtGalleryExhibition.Models.Exhibition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("currentlyRunning")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Exhibition");
                });

            modelBuilder.Entity("ArtGalleryExhibition.Models.Artist", b =>
                {
                    b.HasOne("ArtGalleryExhibition.Models.Exhibition", null)
                        .WithMany("Artists")
                        .HasForeignKey("ExhibitionId");
                });

            modelBuilder.Entity("ArtGalleryExhibition.Models.ArtWork", b =>
                {
                    b.HasOne("ArtGalleryExhibition.Models.Artist", null)
                        .WithMany("ArtWorks")
                        .HasForeignKey("ArtistId");

                    b.HasOne("ArtGalleryExhibition.Models.Exhibition", null)
                        .WithMany("ArtWorks")
                        .HasForeignKey("ExhibitionId");
                });

            modelBuilder.Entity("ArtGalleryExhibition.Models.Artist", b =>
                {
                    b.Navigation("ArtWorks");
                });

            modelBuilder.Entity("ArtGalleryExhibition.Models.Exhibition", b =>
                {
                    b.Navigation("ArtWorks");

                    b.Navigation("Artists");
                });
#pragma warning restore 612, 618
        }
    }
}