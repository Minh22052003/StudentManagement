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
                .ForMember(dest => dest.MaLop, opt => opt.MapFrom(src => src.MaLop))
                .ForMember(dest => dest.MaGV, opt => opt.MapFrom(src => src.GiaoVien.MaGV))
                .ForMember(dest => dest.TenLop, opt => opt.MapFrom(src => src.TenLop));

            CreateMap<List<LopHoc>, LopListResponse>()
                .ForMember(dest => dest.Lops, opt => opt.MapFrom(src => src));

            CreateMap<LopHoc, LopReponseChart>()
                .ForMember(dest => dest.giaovien, opt => opt.MapFrom(src => src.GiaoVien.TenGV))
                .ForMember(dest => dest.tenlop, opt => opt.MapFrom(src => src.TenLop))
                .ForMember(dest => dest.sohocsinh, opt => opt.MapFrom(src => src.SinhViens.Count()));

        }
    }
}
