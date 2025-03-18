using AutoMapper;
using StudentManagement.gRPC.DTOs.Student;
using StudentManagement.NHibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.AutoMap
{
    public class SinhVienMapping : Profile
    {
        public SinhVienMapping()
        {
            CreateMap<SinhVien, SinhVienResponse>()
                .ForMember(dest => dest.NgaySinh, opt => opt.MapFrom(src =>
                    src.NgaySinh.HasValue ? src.NgaySinh.Value.ToString("yyyy-MM-dd") : string.Empty))
                .ForMember(dest => dest.MaLop, opt => opt.MapFrom(src => src.LopHoc.MaLop));

            CreateMap<List<SinhVien>, SinhVienListResponse>()
                .ForMember(dest => dest.SinhViens, opt => opt.MapFrom(src => src));
        }
        
    }
}
