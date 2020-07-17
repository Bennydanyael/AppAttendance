using AppAttendance.Models.Field.Attendances;
using AppAttendance.Models.Field.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models
{
    [Table("AttendancesHistory")]
    public class AttendancesModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoNo { get; set; }
        [Key]
        [Display(Name = "Attendance ID")]
        public int? AttendanceID { get; set; }
        [ForeignKey("AttendanceID")]
        public virtual EmployeeModel Attendances { get; set; }

        [Display(Name ="InputByID")]
        public int? InputByID { get; set; }
        [ForeignKey("InputByID")]
        public virtual InputByType InputByType { get; set; }

        [Display(Name = "EmployeeID")]
        public int? EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual EmployeeModel Employees { get; set; }

        [Display(Name ="PositionID")]
        public int PositionID { get; set; }
        [ForeignKey("PositionID")]
        public virtual PositionTypes Positions { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime AttIN { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yy HH:mm}", ApplyFormatInEditMode =true)]
        public DateTime AttOUT { get; set; }

        private TimeSpan _count { get; set; }
        public int TotalHours
        {
            get
            {
                _count = AttOUT - AttIN;
                return TotalHours;
            }
            set
            {
                TimeSpan _count = AttOUT - AttIN;
            }
        }
    }
}
