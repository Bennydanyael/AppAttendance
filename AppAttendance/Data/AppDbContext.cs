using System;
using System.Collections.Generic;
using System.Text;
using AppAttendance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppAttendance.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //Users
        public DbSet<Pengurus> Pengurus { get; set; }

        //Employee
        public DbSet<Anggota> Anggota{ get; set; }
        
        //Attendances
        public DbSet<Absensi> Absensi { get; set; }

        //Wilayah
        public DbSet<Wilayah> Wilayah { get; set; }
    }
}
