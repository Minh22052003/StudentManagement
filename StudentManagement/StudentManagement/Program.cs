using NHibernate;
using StudentManagement.Data;
using StudentManagement.gRPC.IServices;
using StudentManagement.gRPC.Services;
using StudentManagement.gRPC.AutoMap;
using StudentManagement.NHibernate.DataAccess;
using StudentManagement.NHibernate.IRepositories;
using StudentManagement.NHibernate.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddHttpContextAccessor();

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

// add repo
builder.Services.AddScoped<ISinhVienRepository, SinhVienRepository>();
builder.Services.AddScoped<ILopHocRepository, LopHocRepository>();

// add service
builder.Services.AddScoped<ISinhVienService, SinhVienService>();
builder.Services.AddScoped<ILopHocService, LopHocService>();

string grpcUrl = builder.Configuration.GetSection("gRPC")["Url"] ?? throw new InvalidOperationException("Bug url gRPC");

builder.Services.AddGrpc();
builder.Services.AddHttpClient("gRPC", client =>
{
    client.BaseAddress = new Uri(grpcUrl);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Map gRPC
app.MapGrpcService<SinhVienService>();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
