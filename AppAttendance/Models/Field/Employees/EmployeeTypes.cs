using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models.Field.Employees
{
    public class EmployeeTypes
    {
        [Key]
        public int EmployeeTypeID { get; set; }
        public string EmployeeTypeName { get; set; }
    }
}
