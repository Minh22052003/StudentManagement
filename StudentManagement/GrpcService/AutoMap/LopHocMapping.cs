using AutoMapper;
using Share.DTOs.Lop;
using StudentManagement.NHibernate.Models;

namespace GrpcService.AutoMap
{
    public class LopHocMapping : Profile
    {
        public LopHocMapping()
        {
            CreateMap<LopHoc, LopResponse>()
                .ForMember(dest => dest.MaGV, opt => opt.MapFrom(src => src.GiaoVien.MaGV));

            CreateMap<List<LopHoc>, LopListResponse>()
                .ForMember(dest => dest.Lops, opt => opt.MapFrom(src => src));

            CreateMap<LopHoc, LopReponseChart>()
                .ForMember(dest => dest.giaovien, opt => opt.MapFrom(src => src.GiaoVien.TenGV))
                .ForMember(dest => dest.tenlop, opt => opt.MapFrom(src => src.TenLop))
                .ForMember(dest => dest.sohocsinh, opt => opt.MapFrom(src => src.SinhViens.Count()));

        }
    }
}
