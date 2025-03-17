using StudentManagement.Data;
using StudentManagement.gRPC.Services;
using StudentManagement.NHibernate.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<NHibernateSessionManager>();
builder.Services.AddGrpc();
builder.Services.AddHttpClient("gRPC", client =>
{
    client.BaseAddress = new Uri("https://localhost:7067");
});
builder.Services.AddSingleton<GrpcServiceFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapGrpcService<TeacherServiceImpl>();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
