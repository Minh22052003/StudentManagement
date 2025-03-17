using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.NHibernate.Models
{
    public class SinhVien
    {
        [Key]
        public virtual int MaSV { get; set; }

        [Required]
        [StringLength(100)]
        public virtual string TenSV { get; set; }

        public virtual DateTime? NgaySinh { get; set; }

        [StringLength(255)]
        public virtual string DiaChi { get; set; }

        public virtual int? MaLop { get; set; }
        [ForeignKey("MaLop")]
        public virtual LopHoc LopHoc { get; set; }
    }
}
