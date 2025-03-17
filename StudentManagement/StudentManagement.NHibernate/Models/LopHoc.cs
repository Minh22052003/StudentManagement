using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLySinhVien.Models
{
    public class LopHoc
    {
        [Key]
        public int MaLop { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLop { get; set; }

        [StringLength(100)]
        public string MonHoc { get; set; }

        public int? MaGV { get; set; }
        [ForeignKey("MaGV")]
        public GiaoVien GiaoVien { get; set; }

        public ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
    }
}
