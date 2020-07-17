using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models.Field.Employees
{
    public class DivisionTypes
    {
        [Key]
        public int DivisionID { get; set; }
        public string DivisionName { get; set; }

        public string Descriptions { get; set; }
    }
}
