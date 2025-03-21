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
                .ForMember(dest => dest.MaLop, opt => opt.MapFrom(src => src.LopHoc.MaLop))
                .ForMember(dest => dest.LopResponse, opt => opt.MapFrom(src => src.LopHoc));


            CreateMap<List<SinhVien>, SinhVienListResponse>()
                .ForMember(dest => dest.SinhViens, opt => opt.MapFrom(src => src));

            CreateMap<SinhVienResponse, SinhVien>()
                .ForMember(dest => dest.LopHoc, opt => opt.MapFrom(src => src));

            CreateMap<RequestSinhVienAdd, SinhVien>();


            CreateMap<SinhVienResponse, SinhVien>();
        }
        
    }
}
