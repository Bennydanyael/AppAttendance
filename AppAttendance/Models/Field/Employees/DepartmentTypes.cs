using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models.Field.Employees
{
    public class DepartmentTypes
    {
        [Key]
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        [Display(Name = "DivisionID")]
        public int? DivisionID { get; set; }
        [ForeignKey("DivisionID")]
        public virtual DivisionTypes Divisions { get; set; }
    }
}
