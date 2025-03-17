using Grpc.Net.Client;
using QuickStart.gRPC;

namespace QuickStart.Services
{
    public class GrpcServiceFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GrpcServiceFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public T CreateGrpcClient<T>(Func<GrpcChannel, T> clientFactory)
        {
            var httpClient = _httpClientFactory.CreateClient("gRPC");
            var channel = GrpcChannel.ForAddress("https://localhost:7010", new GrpcChannelOptions { HttpClient = httpClient });

            return clientFactory(channel);
        }
    }
}
