using AutoMapper;
using StudentManagement.gRPC.DTOs.SinhVien;
using StudentManagement.gRPC.IServices;
using StudentManagement.NHibernate.IRepositories;
using StudentManagement.NHibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.Services
{
    public class SinhVienService : ISinhVienService
    {
        private readonly ISinhVienRepository _studentRepository;
        private readonly IMapper _mapper;

        public SinhVienService(ISinhVienRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task AddSinhVienAsync(RequestSinhVienAdd request)
        {
            try
            {

                var student = _mapper.Map<SinhVien>(request);
                var students = await _studentRepository.AddSinhVienAsync(student);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex);
                throw;
            }
        }

        public Task DeleteSinhVienAsync(RequestSinhVien request)
        {
            throw new NotImplementedException();
        }

        public async Task<SinhVienListResponse> GetListSinhVienAsync()
        {
            try
            {
                var students = await _studentRepository.GetSinhVienListAsync();
                foreach (var student in students)
                {
                    Console.WriteLine("Student: " + student.TenSV);
                    Console.WriteLine("lop: " + student.LopHoc.MaLop);
                }
                var studentsResponse = _mapper.Map<SinhVienListResponse>(students);
                return studentsResponse;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Loi "+ ex);
                return null;
            }
        }

        public Task<SinhVienResponse> SearchBySinhVienIdAsync(RequestSinhVien request)
        {
            throw new NotImplementedException();
        }

        public Task<SinhVienListResponse> SortSinhVienListByNameAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateSinhVienAsync(RequestSinhVienAdd request)
        {
            throw new NotImplementedException();
        }
    }
}
