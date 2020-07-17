using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AppAttendance.Models.Users
{
    public class AttendanceUserRoles
    {
        [Display(Name ="UserId")]
        public int UserId { get; set; }
        [ForeignKey("Id")]
        public virtual AttendanceUsers AttendanceUser { get; set; }

        [Display(Name ="RoleId")]
        public int RoleId { get; set; }
        [ForeignKey("Id")]
        public virtual AttendanceRoles AttendanceRole { get; set; }
    }
}
