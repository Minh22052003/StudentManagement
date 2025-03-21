//using GrpcService;
using GrpcService.AutoMap;
using Share.IServices;
using ProtoBuf.Grpc.Server;
using GrpcService.Services;
using NHibernate;
using StudentManagement.NHibernate.DataAccess;
using StudentManagement.NHibernate.IRepositories;
using StudentManagement.NHibernate.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddCodeFirstGrpc();
builder.Services.AddGrpcReflection();

// add NHibernate
builder.Services.AddSingleton<NHibernateSessionManager>();

// add ISessionFactory
builder.Services.AddSingleton(provider =>
{
    var nhHelper = provider.GetRequiredService<NHibernateSessionManager>();
    return nhHelper.GetSessionFactory();
});

// add ISession
builder.Services.AddScoped(provider =>
{
    var sessionFactory = provider.GetRequiredService<ISessionFactory>();
    return sessionFactory.OpenSession();
});

// add auto mapper
builder.Services.AddAutoMapper(typeof(SinhVienMapping));
builder.Services.AddAutoMapper(typeof(LopHocMapping));
builder.Services.AddAutoMapper(typeof(GiaoVienMapping));

// add repo
builder.Services.AddScoped<ISinhVienRepository, SinhVienRepository>();
builder.Services.AddScoped<ILopHocRepository, LopHocRepository>();
builder.Services.AddScoped<IGiaoVienRepository, GiaoVienRepository>();

// add service
builder.Services.AddScoped<ISinhVienService, SinhVienService>();
builder.Services.AddScoped<ILopHocService, LopHocService>();
builder.Services.AddScoped<IGiaoVienService, GiaoVienService>();
builder.Services.AddScoped<IExcelExportService, ExcelExportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Map gRPC
app.MapGrpcService<SinhVienService>();
app.MapGrpcService<LopHocService>();
app.MapGrpcService<GiaoVienService>();
app.MapGrpcService<ExcelExportService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
