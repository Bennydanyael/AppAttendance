using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models.Users
{
    public class AttendanceRoles
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
