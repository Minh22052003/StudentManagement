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
        private readonly ILopHocRepository _lopHocRepository;
        private readonly IMapper _mapper;

        public SinhVienService(ISinhVienRepository studentRepository, ILopHocRepository lopHocRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _lopHocRepository = lopHocRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddSinhVienAsync(RequestSinhVienAdd requestadd)
        {
            bool checkadd = false;
            try
            {
                
                var student = _mapper.Map<SinhVien>(requestadd);
                student.MaLop = requestadd.MaLop;
                student.LopHoc = await _lopHocRepository.GetLopHocById(student.MaLop);
                var requestSV = new RequestSinhVien { MaSV = student.MaSV };
                if (SearchBySinhVienIdAsync(requestSV).Result != null)
                {
                    return checkadd;
                }
                var studentadd = await _studentRepository.AddSinhVienAsync(student);
                if(studentadd == null)
                {
                    return checkadd;
                }
                checkadd = true;
                return checkadd;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex);
                throw;
            }
        }

        public async Task<bool> UpdateSinhVienAsync(SinhVienResponse request)
        {
            bool checkupdate = false;
            try
            {
                var student = _mapper.Map<SinhVien>(request);
                student.MaLop = request.MaLop;
                student.LopHoc = _lopHocRepository.GetLopHocById(student.MaLop).Result;

                var studenttmp = await _studentRepository.GetSinhVienByIDAsync(student.MaSV);
                if (studenttmp == null)
                {
                    return checkupdate;
                }

                studenttmp.TenSV = student.TenSV;
                studenttmp.NgaySinh = student.NgaySinh;
                studenttmp.DiaChi = student.DiaChi;
                studenttmp.MaLop = student.MaLop;
                studenttmp.LopHoc = student.LopHoc;

                var studentupdate = await _studentRepository.UpdateSinhVienAsync(studenttmp);
                if (studentupdate == null)
                {
                    return checkupdate;
                }
                checkupdate = true;
                return checkupdate;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex);
                throw;
            }
        }

        public async Task<bool> DeleteSinhVienAsync(RequestSinhVien request)
        {
            bool checkdelete = false;
            try
            {
                var student = await _studentRepository.GetSinhVienByIDAsync(request.MaSV);
                if (student == null)
                {
                    return checkdelete;
                }

                checkdelete = await _studentRepository.DeleteSinhVienAsync(student);
                return checkdelete;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex);
                throw;
            }
        }

        public async Task<SinhVienListResponse> GetListSinhVienAsync()
        {
            try
            {
                var students = await _studentRepository.GetSinhVienListAsync();
                var studentsResponse = _mapper.Map<SinhVienListResponse>(students);
                return studentsResponse;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Loi "+ ex);
                return null;
            }
        }


        public async Task<SinhVienResponse> SearchBySinhVienIdAsync(RequestSinhVien request)
        {
            try
            {
                var student = await _studentRepository.GetSinhVienByIDAsync(request.MaSV);
                var studentResponse = _mapper.Map<SinhVienResponse>(student);
                return studentResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex);
                return null;
            }
        }

        public async Task<SinhVienListResponse> SortSinhVienListByNameAsync()
        {
            try
            {
                var students = await _studentRepository.GetSinhVienListSortByNameAsync();
                var studentsResponse = _mapper.Map<SinhVienListResponse>(students);
                return (studentsResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex);
                return null;
            }

        }
        
    }
}
