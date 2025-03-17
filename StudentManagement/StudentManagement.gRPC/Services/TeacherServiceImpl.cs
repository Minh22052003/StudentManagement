using Grpc.Core;
using StudentManagement.NHibernate.DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.gRPC.Services
{
    public class TeacherServiceImpl : TeacherService.TeacherServiceBase
    {
        private readonly NHibernateSessionManager _sessionManager;

        public TeacherServiceImpl(NHibernateSessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public override async Task<GetTeacherListReply> GetTeacherList(GetTeacherListRequest request, ServerCallContext context)
        {
            var reply = new GetTeacherListReply();

            try
            {
                using var session = _sessionManager.OpenSession();
                // Lấy danh sách giáo viên từ database bằng NHibernate LINQ
                var teachers = session.Query<StudentManagement.NHibernate.Models.GiaoVien>().ToList();

                reply.Teachers.AddRange(teachers.Select(t => new TeacherInfo
                {
                    MaGV = t.MaGV,
                    TenGV = t.TenGV,
                    NgaySinh = t.NgaySinh.HasValue
                        ? t.NgaySinh.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                        : string.Empty
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching teacher list: " + ex.Message);
            }

            return reply;
        }
    }
}
