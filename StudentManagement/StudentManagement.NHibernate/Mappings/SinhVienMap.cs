using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using StudentManagement.NHibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.NHibernate.Mappings
{
    class SinhVienMap : ClassMap<SinhVien>
    {
        public SinhVienMap()
        {
            Table("SinhVien");
            Id(x=>x.MaSV)
                .Column("MaSV")
                .CustomSqlType("int")
                .GeneratedBy.Identity();
            Map(x => x.TenSV);
            Map(x => x.NgaySinh);
            Map(x => x.DiaChi);
            References(x => x.LopHoc)
                .Column("MaLop")
                .Cascade.None();
        }
    }
}
