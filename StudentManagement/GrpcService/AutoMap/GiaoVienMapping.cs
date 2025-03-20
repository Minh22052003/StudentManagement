using AutoMapper;
using Share.DTOs.GiaoVien;
using StudentManagement.NHibernate.Models;

namespace GrpcService.AutoMap
{
    public class GiaoVienMapping :Profile
    {
        public GiaoVienMapping()
        {
            CreateMap<GiaoVien, GiaoVienResponse>();

            CreateMap<List<GiaoVien>, GiaoVienListResponse>()
                .ForMember(dest => dest.GiaoViens, opt => opt.MapFrom(src => src));

            CreateMap<GiaoVien, GiaoVienSelect>();

            CreateMap<List<GiaoVien>, GiaoVienListSelect>()
                .ForMember(dest => dest.GiaoVienSelects, opt => opt.MapFrom(src => src));
        }
    }
}
