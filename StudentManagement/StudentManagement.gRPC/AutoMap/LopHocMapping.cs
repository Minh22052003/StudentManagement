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
