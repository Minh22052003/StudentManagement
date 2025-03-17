using Grpc.Core;
using QuickStart.gRPC;
using QuickStart.Model;

namespace QuickStart.Services
{
    public class CatServiceImpl : CatService.CatServiceBase
    {
        private readonly NHibernateHelper _nhibernateHelper;

        public CatServiceImpl(NHibernateHelper nhibernateHelper)
        {
            _nhibernateHelper = nhibernateHelper;
        }

        public override async Task<AddCatReply> AddCat(AddCatRequest request, ServerCallContext context)
        {
            var cat = new Cat
            {
                Name = request.Name,
                Sex = string.IsNullOrEmpty(request.Sex) ? ' ' : request.Sex[0],
                Weight = request.Weight
            };

            try
            {
                using var session = _nhibernateHelper.OpenSession();
                using var transaction = session.BeginTransaction();

                session.Save(cat);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                return new AddCatReply { Message = "Error: " + ex.Message };
            }

            return new AddCatReply { Message = "Cat added successfully", CatId = cat.Id };
        }

        public override async Task<GetCatListReply> GetCatList(GetCatListRequest request, ServerCallContext context)
        {
            var reply = new GetCatListReply();

            try
            {
                using var session = _nhibernateHelper.OpenSession();
                var cats = session.Query<Cat>().ToList();
                reply.Cats.AddRange(cats.Select(c => new CatInfo
                {
                    CatId = c.Id,
                    Name = c.Name,
                    Sex = c.Sex.ToString(),
                    Weight = c.Weight
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching cat list: " + ex.Message);
            }

            return reply;
        }
    }
}
