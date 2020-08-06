using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models
{
    [Table("Anggota")]
    public class Anggota
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Kd_anggota { get; set; }
        [Required]
        public string Nama { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime Tgl_lahir { get; set; }
        
        public string Alamat { get; set; }

        public int Kd_Wilayah { get; set; }


        public int Id_Pengurus { get; set; }
        [ForeignKey("IdPengurus")]
        public virtual Pengurus Pengurus { get; set; }
    }
}
