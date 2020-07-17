using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models.Users
{
    public class AttendanceUserTokens
    {
        [Display(Name="UserId")]
        public string UserId { get; set; }
        [ForeignKey("Id")]
        public virtual AttendanceUsers AttendanceUser { get; set; }

        [MaxLength(128)]
        public string LoginProvider { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
