﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(SalesContext))]
    partial class SalesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Domain.Entities.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("Domain.Entities.Flat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Klucz główny tabeli z informacjami o mieszkaniach")
                        .UseIdentityColumn();

                    b.Property<double>("Area")
                        .HasColumnType("float")
                        .HasComment("Powierzchnia mieszkania (w metrach kwadratowych)");

                    b.Property<int?>("AttachmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasComment("Opis ogłoszenia");

                    b.Property<int>("Floor")
                        .HasColumnType("int")
                        .HasComment("Piętro");

                    b.Property<string>("FormOfOwnership")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Forma własności");

                    b.Property<string>("Heating")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Rodzaj ogrzewania");

                    b.Property<string>("KindOfBalcony")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Typ balkonu (jeśli brak - wartość pusta)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("int")
                        .HasComment("Liczba pokoi");

                    b.Property<string>("ParkingSpace")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Parking (jeśli brak - wartość pusta)");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasComment("Cena (za metr kwadratowy)");

                    b.Property<string>("StateOfCompletion")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Status wykończenia mieszkania");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Tytuł ogłoszenia");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentId");

                    b.ToTable("Flats");
                });

            modelBuilder.Entity("Domain.Entities.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Main")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("FlatPicture", b =>
                {
                    b.Property<int>("FlatsId")
                        .HasColumnType("int");

                    b.Property<int>("PicturesId")
                        .HasColumnType("int");

                    b.HasKey("FlatsId", "PicturesId");

                    b.HasIndex("PicturesId");

                    b.ToTable("FlatPicture");
                });

            modelBuilder.Entity("Domain.Entities.Flat", b =>
                {
                    b.HasOne("Domain.Entities.Attachment", null)
                        .WithMany("Flats")
                        .HasForeignKey("AttachmentId");
                });

            modelBuilder.Entity("FlatPicture", b =>
                {
                    b.HasOne("Domain.Entities.Flat", null)
                        .WithMany()
                        .HasForeignKey("FlatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Picture", null)
                        .WithMany()
                        .HasForeignKey("PicturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Attachment", b =>
                {
                    b.Navigation("Flats");
                });
#pragma warning restore 612, 618
        }
    }
}
