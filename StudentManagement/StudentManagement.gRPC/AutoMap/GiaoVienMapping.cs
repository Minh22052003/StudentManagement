using AutoMapper;
using StudentManagement.gRPC.DTOs.GiaoVien;
using StudentManagement.NHibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.AutoMap
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
