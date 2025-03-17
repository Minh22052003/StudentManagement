using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLySinhVien.Models
{
    public class SinhVien
    {
        [Key]
        public int MaSV { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSV { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        public int? MaLop { get; set; }
        [ForeignKey("MaLop")]
        public LopHoc LopHoc { get; set; }
    }
}
