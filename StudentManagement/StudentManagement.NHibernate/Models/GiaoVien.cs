using System.ComponentModel.DataAnnotations;

namespace StudentManagement.NHibernate.Models
{
    public class GiaoVien
    {
        public virtual int MaGV { get; set; }

        public virtual string TenGV { get; set; }

        public virtual DateTime? NgaySinh { get; set; }

        public virtual ICollection<LopHoc> LopHocs { get; set; } = new List<LopHoc>();
    }
}
