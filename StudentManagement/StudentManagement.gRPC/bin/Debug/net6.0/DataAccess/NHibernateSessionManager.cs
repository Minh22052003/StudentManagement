using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Http;
using NHibernate;
using NHibernate.Cfg;
using StudentManagement.NHibernate.Mappings;
using ISession = NHibernate.ISession;

namespace StudentManagement.NHibernate.DataAccess
{
    public class NHibernateSessionManager
    {
        private static readonly ISessionFactory _sessionFactory;

        static NHibernateSessionManager()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(@"Server=DESKTOP-CNFI749\SQLEXPRESS01;Database=QuanLySinhVien;Integrated Security=True")
                    .ShowSql()
                ).Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<GiaoVienMap>();
                    m.FluentMappings.AddFromAssemblyOf<LopHocMap>();
                    m.FluentMappings.AddFromAssemblyOf<SinhVienMap>();
                })
                .BuildSessionFactory();
        }

        public ISessionFactory GetSessionFactory()
        {
            return _sessionFactory;
        }

        public static ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
