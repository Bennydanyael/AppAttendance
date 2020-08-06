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

        [Display(Name ="Wilayah")]
        public int Kd_wilayah { get; set; }
        [ForeignKey("Kd_wilayah")]
        public virtual Wilayah Wilayah { get; set; }

        [Display(Name ="Pengurus")]
        public int IdPengurus { get; set; }
        [ForeignKey("IdPengurus")]
        public virtual Pengurus Pengurus { get; set; }
    }
}
