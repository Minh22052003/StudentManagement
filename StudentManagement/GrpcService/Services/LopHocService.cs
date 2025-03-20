using AutoMapper;
using Share.IServices;
using Share.DTOs.GiaoVien;
using Share.DTOs.Lop;
using StudentManagement.NHibernate.IRepositories;
using StudentManagement.NHibernate.Models;

namespace GrpcService.Services
{
    public class LopHocService : ILopHocService
    {
        private readonly ILopHocRepository _lopHocRepository;
        private readonly IMapper _mapper;

        public LopHocService(ILopHocRepository lopHocRepository, IMapper mapper)
        {
            _lopHocRepository = lopHocRepository;
            _mapper = mapper;
        }

        public async Task<LopListResponse> GetListLopAsync()
        {
            try
            {
                var lopHocs = await _lopHocRepository.GetLopHocListAsync();
                var lopHocResponse = _mapper.Map<LopListResponse>(lopHocs);
                return lopHocResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi " + ex);
                return null;
            }
        }

        public async Task<List<LopReponseChart>> SearchByGiaoVienIdAsync(RequestGiaoVien requestGiaoVien)
        {
            try
            {
                List<LopHoc> lophocs = await _lopHocRepository.GetLopHocByGiaoVien(requestGiaoVien.MaGV);
                List<LopReponseChart> lopResponses = new List<LopReponseChart>();

                foreach (var lop in lophocs)
                {
                    var lopResponse = _mapper.Map<LopReponseChart>(lop);
                    lopResponses.Add(lopResponse);
                }

                return lopResponses;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
                return null;
            }
        }


        async Task<LopResponse> ILopHocService.SearchByLopHocIdAsync(RequestLop requestLop)
        {
            try
            {
                var lopHoc = await _lopHocRepository.GetLopHocById(requestLop.MaLop);
                var lopHocResponse = _mapper.Map<LopResponse>(lopHoc);
                return lopHocResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi " + ex);
                return null;
            }
        }
    }
}
