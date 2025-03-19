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
    class LopHocMap : ClassMap<LopHoc>
    {
        public LopHocMap()
        {
            Table("LopHoc");

            Id(x => x.MaLop)
                .Column("MaLop")
                .CustomSqlType("int");

            Map(x => x.TenLop).Column("TenLop");
            Map(x => x.MonHoc).Column("MonHoc");

            References(x => x.GiaoVien)
                .Column("MaGV")
                .Cascade.None();

            HasMany(x => x.SinhViens)
                .KeyColumn("MaLop")
                .Inverse()
                .Cascade.All();
        }
    }
}
