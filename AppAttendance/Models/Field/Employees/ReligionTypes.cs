using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models.Field.Employees
{
    public class ReligionTypes
    {
        [Key]
        public int ReligionID { get; set; }
        public string ReligionName { get; set; }
    }
}
