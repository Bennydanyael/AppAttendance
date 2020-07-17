using System;
using System.Collections.Generic;
using System.Text;
using AppAttendance.Models;
using AppAttendance.Models.Field.Attendances;
using AppAttendance.Models.Field.Employees;
using AppAttendance.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppAttendance.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Users
        //public DbSet<AttendanceRoleClaims> AttendanceRoleClaims { get; set; }
        //public DbSet<AttendanceRoles> AttendanceRoles { get; set; }
        //public DbSet<AttendanceUserClaims> AttendanceUserClaims { get; set; }
        //public DbSet<AttendanceUserLogins> AttendanceUserLogins { get; set; }
        //public DbSet<AttendanceUserRoles> AttendanceUserRoles { get; set; }
        //public DbSet<AttendanceUsers> AttendanceUsers { get; set; }
        //public DbSet<AttendanceUserTokens> AttendanceUserTokens { get; set; }

        //Employee
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<DepartmentTypes> DepartmentTypes { get; set; }
        public DbSet<DivisionTypes> DivisionTypes { get; set; }
        public DbSet<EmployeeTypes> EmployeeTypes { get; set; }
        public DbSet<GenderTypes> GenderTypes { get; set; }
        public DbSet<MaritalTypes> MaritalTypes { get; set; }
        public DbSet<PositionTypes> PositionTypes { get; set; }
        public DbSet<ReligionTypes> ReligionTypes { get; set; }
        public DbSet<SectionTypes> SectionTypes { get; set; }

        //Attendances
        public DbSet<AttendancesModel> Attendances { get; set; }
        public DbSet<InputByType> InputByTypes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=HOKAGE\\SQLSERVER2017;Database=aspnet-AppAttendance-FACC7CBF-792B-4BCC-80C2-D17153E6CA0D;Trusted_Connection=True;MultipleActiveResultSets=true; App = EntityFramework & quot; ");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
