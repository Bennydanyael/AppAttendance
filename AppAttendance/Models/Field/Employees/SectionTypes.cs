using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models.Field.Employees
{
    public class SectionTypes
    {
        [Key]
        public int SectionID { get; set; }
        public string SectionName { get; set; }

        [Display(Name ="DepartmentID")]
        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual DepartmentTypes Departments { get; set; }

        //[Display(Name ="DivisionID")]
        //public int DivisionID { get; set; }
        //[ForeignKey("DivisionID")]
        //public virtual DivisionTypes Divisions { get; set; }
    }
}
