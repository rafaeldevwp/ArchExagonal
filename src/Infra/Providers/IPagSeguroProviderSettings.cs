using Bussiness.Configs;

namespace Infra.Providers
{
    public interface IPagSeguroProviderSettings : IBaseApi
    {
        string Token { get; set; }
        string Email { get; set; }
        string appId { get; set; }
        string AppKey { get; set; }
    }
}