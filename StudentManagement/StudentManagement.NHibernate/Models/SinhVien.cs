using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.NHibernate.Models
{
    public class SinhVien
    {
        public virtual int MaSV { get; set; }

        public virtual string TenSV { get; set; }

        public virtual DateTime? NgaySinh { get; set; }

        public virtual string DiaChi { get; set; }

        public virtual int MaLop { get; set; }

        public virtual LopHoc LopHoc { get; set; }
    }
}
