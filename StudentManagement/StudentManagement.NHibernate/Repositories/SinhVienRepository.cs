﻿using NHibernate;
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
    public class SinhVienRepository : Repository<SinhVien>, ISinhVienRepository
    {
        private readonly ISession _session;
        public SinhVienRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public async Task<List<SinhVien>> GetSinhVienListAsync()
        {
            var sinhviens = new List<SinhVien>();
            try
            {
                sinhviens = await _session.Query<SinhVien>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.ToString());
                throw;
            }
            return sinhviens;
        }

        public async Task<List<SinhVien>> GetSinhVienListSortByNameAsync(int pageNumber, int pageSize)
        {
            return await _session.Query<SinhVien>().OrderBy(x => x.TenSV).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
