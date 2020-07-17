using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models.Field.Employees
{
    public class PositionTypes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PositionID { get; set; }
        public string PositionName { get; set; }

        [Display(Name = "SectionID")]
        public int SectionID { get; set; }
        [ForeignKey("SectionID")]
        public virtual SectionTypes Sections { get; set; }
    }
}
