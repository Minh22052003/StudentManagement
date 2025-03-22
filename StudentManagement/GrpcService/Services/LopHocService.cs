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
                throw;
            }
        }

        public async Task<List<LopReponseChart>> SearchLopHocByGiaoVienIdAsync(string MaGV)
        {
            try
            {
                List<LopHoc> lophocs = await _lopHocRepository.GetLopHocByGiaoVien(int.Parse(MaGV));
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
                throw;
            }
        }


    }
}
