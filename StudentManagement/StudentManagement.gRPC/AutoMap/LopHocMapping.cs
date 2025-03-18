using AutoMapper;
using StudentManagement.gRPC.DTOs.Lop;
using StudentManagement.gRPC.DTOs.SinhVien;
using StudentManagement.NHibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.AutoMap
{
    class LopHocMapping : Profile
    {
        public LopHocMapping()
        {
            CreateMap<LopHoc, LopResponse>()
                .ForMember(dest => dest.MaGV, opt => opt.MapFrom(src => src.GiaoVien.MaGV));

            CreateMap<List<LopHoc>, LopListResponse>()
                .ForMember(dest => dest.Lops, opt => opt.MapFrom(src => src));
        }
    }
}
