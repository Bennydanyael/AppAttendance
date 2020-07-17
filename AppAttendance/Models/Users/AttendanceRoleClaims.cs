using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models.Users
{
    public class AttendanceRoleClaims
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        
        [Display(Name="RoleId")]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual AttendanceRoles AttendanceRoles{ get; set; }

        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
