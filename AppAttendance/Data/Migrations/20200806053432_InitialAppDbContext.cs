using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAttendance.Data.Migrations
{
    public partial class InitialAppDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pengurus",
                columns: table => new
                {
                    IdPengurus = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Passwords = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pengurus", x => x.IdPengurus);
                });

            migrationBuilder.CreateTable(
                name: "Wilayah",
                columns: table => new
                {
                    Kd_wilayah = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama_Wilayah = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wilayah", x => x.Kd_wilayah);
                });

            migrationBuilder.CreateTable(
                name: "Anggota",
                columns: table => new
                {
                    Kd_anggota = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(nullable: false),
                    Tgl_lahir = table.Column<DateTime>(nullable: false),
                    Alamat = table.Column<string>(nullable: true),
                    Kd_wilayah = table.Column<int>(nullable: false),
                    IdPengurus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anggota", x => x.Kd_anggota);
                    table.ForeignKey(
                        name: "FK_Anggota_Pengurus_IdPengurus",
                        column: x => x.IdPengurus,
                        principalTable: "Pengurus",
                        principalColumn: "IdPengurus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Anggota_Wilayah_Kd_wilayah",
                        column: x => x.Kd_wilayah,
                        principalTable: "Wilayah",
                        principalColumn: "Kd_wilayah",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absensi",
                columns: table => new
                {
                    Kd_absen = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kd_anggota = table.Column<int>(nullable: false),
                    Kd_wilayah = table.Column<int>(nullable: false),
                    Keterangan = table.Column<string>(nullable: true),
                    Tanggal = table.Column<DateTime>(nullable: false),
                    Selesai = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absensi", x => x.Kd_absen);
                    table.ForeignKey(
                        name: "FK_Absensi_Anggota_Kd_anggota",
                        column: x => x.Kd_anggota,
                        principalTable: "Anggota",
                        principalColumn: "Kd_anggota",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Absensi_Wilayah_Kd_wilayah",
                        column: x => x.Kd_wilayah,
                        principalTable: "Wilayah",
                        principalColumn: "Kd_wilayah",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absensi_Kd_anggota",
                table: "Absensi",
                column: "Kd_anggota");

            migrationBuilder.CreateIndex(
                name: "IX_Absensi_Kd_wilayah",
                table: "Absensi",
                column: "Kd_wilayah");

            migrationBuilder.CreateIndex(
                name: "IX_Anggota_IdPengurus",
                table: "Anggota",
                column: "IdPengurus");

            migrationBuilder.CreateIndex(
                name: "IX_Anggota_Kd_wilayah",
                table: "Anggota",
                column: "Kd_wilayah");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absensi");

            migrationBuilder.DropTable(
                name: "Anggota");

            migrationBuilder.DropTable(
                name: "Pengurus");

            migrationBuilder.DropTable(
                name: "Wilayah");
        }
    }
}
