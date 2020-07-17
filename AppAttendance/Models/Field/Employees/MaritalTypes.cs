using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models.Field.Employees
{
    public class MaritalTypes
    {
        [Key]
        public int MaritalID { get; set; }
        public string MaritalName { get; set; }
    }
}
