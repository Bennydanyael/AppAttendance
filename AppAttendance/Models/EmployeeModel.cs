using AppAttendance.Models.Field.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models
{
    [Table("EmployeeMaster")]
    public class EmployeeModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int AutoNo { get; set; }
        [Key]
        [Required]
        public int EmployeeID { get; set; }

        public int AttendanceID { get; set; }
        
        [Required]
        public string FullName { get; set; }
        public string NickName { get; set; }
        
        [Required]
        [Display(Name = "DivisionID")]
        public int? DivisionID { get; set; }
        [ForeignKey("DivisionID")]
        public virtual DivisionTypes Divisions { get; set; }
        
        [Required]
        [Display(Name = "DepartmentID")]
        public int? DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual DepartmentTypes Departments { get; set; }
        
        [Required]
        [Display(Name = "SectionID")]
        public int? SectionID { get; set; }
        [ForeignKey("SectionID")]
        public virtual SectionTypes Sections { get; set; }

        [Required]
        [Display(Name = "PositionID")]
        public int? PositionID { get; set; }
        [ForeignKey("PositionID")]
        public virtual PositionTypes Positions { get; set; }

        [Required]
        [Display(Name = "GenderID")]
        public int? GenderID { get; set; }
        [ForeignKey("GenderID")]
        public virtual GenderTypes Genders { get; set; }

        public string PlaceOfBirth { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime DateOfBirth { get; set; }
        
        public int Age 
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
            set
            {
                int _count = DateTime.Now.Year - DateOfBirth.Year;
            }
        }

        [Display(Name ="MaritalID")]
        public int? MaritalID { get; set; }
        [ForeignKey("MaritalID")]
        public virtual MaritalTypes Maritals { get; set; }

        [Display(Name ="EmployeeTypeID")]
        public int? EmployeeTypeID  { get; set; }
        [ForeignKey("EmployeeTypeID")]
        public virtual EmployeeTypes EmployeeTypes { get; set; }

        [Display(Name ="Religions")]
        public int? ReligionID { get; set; }
        [ForeignKey("ReligionID")]
        public virtual ReligionTypes Religions { get; set; }

        public int? Education { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime YearEducation { get; set; }
        

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime DateJoin { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartContract { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndContract { get; set; }

        [Display(Name = "CardType")]
        public int? CardTypeID { get; set; }
        [ForeignKey("CardTypeID")]

        public string PersonalEmail { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }
}
