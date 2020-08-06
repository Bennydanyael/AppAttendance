using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppAttendance.Models
{
    [Table("Absensi")]
    public class Absensi
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Kd_absen { get; set; }

        [Display(Name ="Anggota")]
        public int Kd_anggota { get; set; }
        [ForeignKey("Kd_anggota")]
        public virtual Anggota Anggota { get; set; }

        public int Kd_Wilayah { get; set; }
        [ForeignKey("Kd_wilayah")]
        public virtual Wilayah Wilayah { get; set; }
        
        public string Keterangan { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Tanggal { get; set; }
        public string Selesai { get; set; }
    }
}
