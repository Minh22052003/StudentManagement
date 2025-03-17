using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.NHibernate.Models
{
    public class LopHoc
    {
        [Key]
        public virtual int MaLop { get; set; }

        [Required]
        [StringLength(100)]
        public virtual string TenLop { get; set; }

        [StringLength(100)]
        public virtual string MonHoc { get; set; }

        public virtual int? MaGV { get; set; }
        [ForeignKey("MaGV")]
        public virtual GiaoVien GiaoVien { get; set; }

        public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
    }
}
