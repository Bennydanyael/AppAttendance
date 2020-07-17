using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models.Field.Attendances
{
    [Table("InputByType")]
    public class InputByType
    {
        [Key]
        public int InputByID { get; set; }
        public string InputByName { get; set; }
    }
}
