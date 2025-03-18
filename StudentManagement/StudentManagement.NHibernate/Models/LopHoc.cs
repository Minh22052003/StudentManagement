using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.NHibernate.Models
{
    public class LopHoc
    {
        public virtual int MaLop { get; set; }

        public virtual string TenLop { get; set; }

        public virtual string MonHoc { get; set; }

        public virtual int? MaGV { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
    }
}
