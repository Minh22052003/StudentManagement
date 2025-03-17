using System.ComponentModel.DataAnnotations;

namespace StudentManagement.NHibernate.Models
{
    public class GiaoVien
    {
        [Key]
        public virtual int MaGV { get; set; }

        [Required]
        [StringLength(100)]
        public virtual string TenGV { get; set; }

        public virtual DateTime? NgaySinh { get; set; }

        public virtual ICollection<LopHoc> LopHocs { get; set; } = new List<LopHoc>();
    }
}
