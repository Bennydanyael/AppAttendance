﻿// <auto-generated />
using System;
using AppAttendance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppAttendance.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200806053432_InitialAppDbContext")]
    partial class InitialAppDbContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppAttendance.Models.Absensi", b =>
                {
                    b.Property<int>("Kd_absen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kd_anggota")
                        .HasColumnType("int");

                    b.Property<int>("Kd_wilayah")
                        .HasColumnType("int");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Selesai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime2");

                    b.HasKey("Kd_absen");

                    b.HasIndex("Kd_anggota");

                    b.HasIndex("Kd_wilayah");

                    b.ToTable("Absensi");
                });

            modelBuilder.Entity("AppAttendance.Models.Anggota", b =>
                {
                    b.Property<int>("Kd_anggota")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alamat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPengurus")
                        .HasColumnType("int");

                    b.Property<int>("Kd_wilayah")
                        .HasColumnType("int");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tgl_lahir")
                        .HasColumnType("datetime2");

                    b.HasKey("Kd_anggota");

                    b.HasIndex("IdPengurus");

                    b.HasIndex("Kd_wilayah");

                    b.ToTable("Anggota");
                });

            modelBuilder.Entity("AppAttendance.Models.Pengurus", b =>
                {
                    b.Property<int>("IdPengurus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Passwords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPengurus");

                    b.ToTable("Pengurus");
                });

            modelBuilder.Entity("AppAttendance.Models.Wilayah", b =>
                {
                    b.Property<int>("Kd_wilayah")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nama_Wilayah")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Kd_wilayah");

                    b.ToTable("Wilayah");
                });

            modelBuilder.Entity("AppAttendance.Models.Absensi", b =>
                {
                    b.HasOne("AppAttendance.Models.Anggota", "Anggota")
                        .WithMany()
                        .HasForeignKey("Kd_anggota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppAttendance.Models.Wilayah", "Wilayah")
                        .WithMany()
                        .HasForeignKey("Kd_wilayah")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppAttendance.Models.Anggota", b =>
                {
                    b.HasOne("AppAttendance.Models.Pengurus", "Pengurus")
                        .WithMany()
                        .HasForeignKey("IdPengurus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppAttendance.Models.Wilayah", "Wilayah")
                        .WithMany()
                        .HasForeignKey("Kd_wilayah")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
