using AutoMapper;
using Share.IServices;
using Share.DTOs.GiaoVien;
using StudentManagement.NHibernate.IRepositories;

namespace GrpcService.Services
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

        public async Task<GiaoVienListSelect> GetAllGiaoVienAsync()
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
                throw;
            }
        }

    }
}
