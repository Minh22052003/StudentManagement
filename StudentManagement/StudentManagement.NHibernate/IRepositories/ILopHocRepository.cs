﻿using StudentManagement.NHibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.NHibernate.IRepositories
{
    public interface ILopHocRepository : IRepository<LopHoc>
    {
        Task<List<LopHoc>> GetLopHocListAsync();

        Task<LopHoc> GetLopHocById(int id);
    }
}
