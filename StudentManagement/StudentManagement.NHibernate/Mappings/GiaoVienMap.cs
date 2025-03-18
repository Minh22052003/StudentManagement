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
    class GiaoVienMap : ClassMap<GiaoVien>
    {
        public GiaoVienMap()
        {
            Table("GiaoVien");
            Id(x=>x.MaGV)
                .Column("MaGV")
                .CustomSqlType("int")
                .GeneratedBy.Identity();
            Map(x => x.TenGV);
            Map(x => x.NgaySinh);
            HasMany(x => x.LopHocs)
                .KeyColumn("MaGV")
                .Inverse()
                .Cascade.All();
        }
    }
}
