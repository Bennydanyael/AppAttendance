using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models.Users
{
    public class AttendanceUserClaims
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Display(Name ="UserId")]
        public string UserId { get; set; }
        [ForeignKey("Id")]
        public virtual AttendanceUsers AttendanceUser { get; set; }

        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
