using AutoMapper;
using StudentManagement.gRPC.DTOs.SinhVien;
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
                .ForMember(dest => dest.MaLop, opt => opt.MapFrom(src => src.LopHoc.MaLop));

            CreateMap<List<SinhVien>, SinhVienListResponse>()
                .ForMember(dest => dest.SinhViens, opt => opt.MapFrom(src => src));

            CreateMap<SinhVienResponse, SinhVien>();

            CreateMap<RequestSinhVienAdd, SinhVien>();
        }
        
    }
}
