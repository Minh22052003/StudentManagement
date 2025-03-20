using AutoMapper;
using Share.DTOs.SinhVien;
using StudentManagement.NHibernate.Models;

namespace GrpcService.AutoMap
{
    public class SinhVienMapping : Profile
    {
        public SinhVienMapping()
        {
            CreateMap<SinhVien, SinhVienResponse>()
                .ForMember(dest => dest.MaLop, opt => opt.MapFrom(src => src.LopHoc.MaLop));

            CreateMap<List<SinhVien>, SinhVienListResponse>()
                .ForMember(dest => dest.SinhViens, opt => opt.MapFrom(src => src));

            CreateMap<SinhVienResponse, SinhVien>();

            CreateMap<RequestSinhVienAdd, SinhVien>();
        }
        
    }
}
