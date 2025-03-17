using System.ComponentModel.DataAnnotations;

namespace QuanLySinhVien.Models
{
    public class GiaoVien
    {
        [Key]
        public int MaGV { get; set; }

        [Required]
        [StringLength(100)]
        public string TenGV { get; set; }

        public DateTime? NgaySinh { get; set; }
        
        public ICollection<LopHoc> LopHocs { get; set; } = new List<LopHoc>();
    }
}
