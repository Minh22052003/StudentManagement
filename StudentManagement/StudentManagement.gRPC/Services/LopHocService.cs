using AutoMapper;
using StudentManagement.gRPC.DTOs.Lop;
using StudentManagement.gRPC.DTOs.SinhVien;
using StudentManagement.gRPC.IServices;
using StudentManagement.NHibernate.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.Services
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
