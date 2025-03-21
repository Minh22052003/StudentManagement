using AutoMapper;
using Share.IServices;
using Share.DTOs.SinhVien;
using StudentManagement.NHibernate.IRepositories;
using StudentManagement.NHibernate.Models;
using Share.DTOs.Common;

namespace GrpcService.Services
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
        public async Task<BoolResponse> AddSinhVienAsync(RequestSinhVienAdd requestadd)
        {
            BoolResponse checkadd = new();
            checkadd.Success = false;
            try
            {
                
                var student = _mapper.Map<SinhVien>(requestadd);
                student.MaLop = requestadd.MaLop;
                student.LopHoc = await _lopHocRepository.GetLopHocById(student.MaLop);
                var requestSV = new RequestSinhVien { MaSV = student.MaSV };
                if (await SearchBySinhVienIdAsync(requestSV) != null)
                {
                    return checkadd;
                }
                var studentadd = await _studentRepository.AddSinhVienAsync(student);
                if(studentadd == null)
                {
                    return checkadd;
                }
                checkadd.Success = true;
                return checkadd;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<BoolResponse> UpdateSinhVienAsync(SinhVienResponse request)
        {
            BoolResponse checkupdate = new();
            checkupdate.Success = false;
            try
            {
                var student = _mapper.Map<SinhVien>(request);
                student.MaLop = request.MaLop;
                student.LopHoc = await _lopHocRepository.GetLopHocById(student.MaLop);

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
                checkupdate.Success = true;
                return checkupdate;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<BoolResponse> DeleteSinhVienAsync(RequestSinhVien request)
        {
            BoolResponse checkdelete = new();
            checkdelete.Success = false;
            try
            {
                var student = await _studentRepository.GetSinhVienByIDAsync(request.MaSV);
                if (student == null)
                {
                    return checkdelete;
                }

                checkdelete.Success = await _studentRepository.DeleteSinhVienAsync(student);
                return checkdelete;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SinhVienPageResponse> GetListSinhVienAsync(PageFilterRequest pageFilterRequest)
        {
            try
            {

                var students = await _studentRepository.GetSinhVienListAsync(pageFilterRequest.PageChange.PageSize, pageFilterRequest.PageChange.PageIndex, pageFilterRequest.IDSinhVien, pageFilterRequest.IsSortByNameSinhVien);
                var studentsResponse = new List<SinhVienResponse>();
                for (int i = 0; i < students.Count; i++)
                {
                    studentsResponse.Add(_mapper.Map<SinhVienResponse>(students[i]));
                }
                var studentPageResponse = new SinhVienPageResponse();
                studentPageResponse.SinhViens = studentsResponse;
                if(pageFilterRequest.IDSinhVien != null)
                {
                    studentPageResponse.Total = 1;
                }
                else
                {
                    studentPageResponse.Total = await _studentRepository.GetTotalSinhVienAsync();
                }

                return studentPageResponse;
            }
            catch(Exception ex)
            {
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
                return null;
            }
        }

        public async Task<List<SinhVienResponse>> SortSinhVienListByNameAsync(PageChange pageChange)
        {
            try
            {
                var students = await _studentRepository.GetSinhVienListSortByNameAsync(pageChange.PageSize, pageChange.PageIndex);
                var studentsResponse = new List<SinhVienResponse>();
                for (int i = 0; i < students.Count; i++)
                {
                    studentsResponse.Add(_mapper.Map<SinhVienResponse>(students[i]));
                }
                return studentsResponse;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<PageTotalResponse> GetPageTotalAsync()
        {
            try
            {
                var pageChange = new PageTotalResponse();
                pageChange.Total = await _studentRepository.GetTotalSinhVienAsync();
                return pageChange;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
