using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Share.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpContextAccessor();

// add AntDesign
builder.Services.AddAntDesign();

string grpcUrl = builder.Configuration.GetSection("gRPC")["Url"] ?? throw new InvalidOperationException("Bug url gRPC");
// Configure HttpClient for gRPC
builder.Services.AddHttpClient("gRPC", client =>
{
    client.BaseAddress = new Uri(grpcUrl);
}).ConfigurePrimaryHttpMessageHandler(() =>
    new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    });

// Create GrpcChannel using HttpClientFactory
builder.Services.AddSingleton(serviceProvider =>
{
    var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient("gRPC");
    return GrpcChannel.ForAddress(grpcUrl, new GrpcChannelOptions { HttpClient = httpClient });
});

// Register gRPC services
builder.Services.AddSingleton<ISinhVienService>(serviceProvider =>
    serviceProvider.GetRequiredService<GrpcChannel>().CreateGrpcService<ISinhVienService>());
builder.Services.AddSingleton<IGiaoVienService>(serviceProvider =>
    serviceProvider.GetRequiredService<GrpcChannel>().CreateGrpcService<IGiaoVienService>());
builder.Services.AddSingleton<ILopHocService>(serviceProvider =>
    serviceProvider.GetRequiredService<GrpcChannel>().CreateGrpcService<ILopHocService>());
builder.Services.AddSingleton<IExcelExportService>(serviceProvider =>
    serviceProvider.GetRequiredService<GrpcChannel>().CreateGrpcService<IExcelExportService>());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
