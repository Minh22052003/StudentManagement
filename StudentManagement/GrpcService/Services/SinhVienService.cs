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

        public async Task<SinhVienPageResponse> GetListSinhVienAsync(PageFilterRequest pageFilterRequest)
        {
            try
            {

                var students = await _studentRepository.GetSinhVienPageAsync(pageFilterRequest.PageChange.PageSize, pageFilterRequest.PageChange.PageIndex, pageFilterRequest.IDSinhVien, pageFilterRequest.IsSortByNameSinhVien);
                var studentsResponse = new List<SinhVienResponse>();
                for (int i = 0; i < students.Count; i++)
                {
                    studentsResponse.Add(_mapper.Map<SinhVienResponse>(students[i]));
                }
                var studentPageResponse = new SinhVienPageResponse();
                studentPageResponse.SinhViens = studentsResponse;
                if (pageFilterRequest.IDSinhVien != null)
                {
                    studentPageResponse.Total = 1;
                }
                else
                {
                    studentPageResponse.Total = await _studentRepository.CountSinhVienAsync();
                }

                return studentPageResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SinhVienResponse> GetSinhVienByIDAsync(string MaSV)
        {
            try
            {
                var student = await _studentRepository.GetSinhVienByIDAsync(int.Parse(MaSV));
                var studentResponse = _mapper.Map<SinhVienResponse>(student);
                return studentResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
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

                var studentadd = await _studentRepository.AddSinhVienAsync(student);

                checkadd.Success = studentadd;
                return checkadd;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return checkadd;
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

                var studentupdate = await _studentRepository.UpdateSinhVienAsync(student);
                
                checkupdate.Success = studentupdate;
                return checkupdate;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return checkupdate;
            }
        }

        public async Task<BoolResponse> DeleteSinhVienAsync(string MaSV)
        {
            BoolResponse checkdelete = new();
            checkdelete.Success = false;
            try
            {
                checkdelete.Success = await _studentRepository.DeleteSinhVienAsync(int.Parse(MaSV));
                return checkdelete;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
