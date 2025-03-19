using AutoMapper;
using NHibernate.Mapping;
using StudentManagement.gRPC.DTOs.GiaoVien;
using StudentManagement.gRPC.IServices;
using StudentManagement.NHibernate.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.Services
{
    public class GiaoVienService : IGiaoVienService
    {
        private readonly IGiaoVienRepository _giaoVienRepository;
        private readonly IMapper _mapper;

        public GiaoVienService(IGiaoVienRepository giaoVienRepository, IMapper mapper)
        {
            _giaoVienRepository = giaoVienRepository;
            _mapper = mapper;
        }
        public async Task<GiaoVienListResponse> GetListGiaoVienAsync()
        {
            var listGV = await _giaoVienRepository.GetGiaoVienListAsync();
            var giaoviens = _mapper.Map<GiaoVienListResponse>(listGV);
            return giaoviens;
        }

        public async Task<GiaoVienListSelect> GetListGiaoVienSelectAsync()
        {
            try
            {
                var listGV = await _giaoVienRepository.GetGiaoVienListAsync();
                var giaoviens = _mapper.Map<GiaoVienListSelect>(listGV);
                return giaoviens;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi " + ex);
                return null;
            }
        }

        public Task<GiaoVienResponse> SearchByGiaoVienIdAsync(RequestGiaoVien requestGiaoVien)
        {
            throw new NotImplementedException();
        }
    }
}
