using NHibernate;
using NHibernate.Linq;
using StudentManagement.NHibernate.IRepositories;
using StudentManagement.NHibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.NHibernate.Repositories
{
    public class GiaoVienRepository : IGiaoVienRepository
    {
        private readonly ISession _session;
        public GiaoVienRepository(ISession session)
        {
            _session = session;
        }
        public Task<GiaoVien> AddGiaoVienAsync(GiaoVien giaoVien)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGiaoVienAsync(GiaoVien giaoVien)
        {
            throw new NotImplementedException();
        }

        public Task<GiaoVien> GetGiaoVienByIDAsync(int id)
        {
            return _session.GetAsync<GiaoVien>(id);
        }

        public Task<List<GiaoVien>> GetGiaoVienListAsync()
        {
            return _session.Query<GiaoVien>().ToListAsync();
        }

        public Task<List<GiaoVien>> GetGiaoVienListBySinhVienAsync(SinhVien sinhVien)
        {
            throw new NotImplementedException();
        }

        public Task<List<GiaoVien>> GetGiaoVienListSortByNameAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GiaoVien> UpdateGiaoVienAsync(GiaoVien giaoVien)
        {
            throw new NotImplementedException();
        }
    }
}
