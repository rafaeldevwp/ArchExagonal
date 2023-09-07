using Bussiness.Configs;

namespace Infra.Providers.Configs
{
    public class PagSeguroProviderSettings : AbstractBaseApi, IPagSeguroProviderSettings
    {

        public string Token { get; set; }
        public string Email { get; set; }
        public string appId { get; set; }
        public string AppKey { get; set; }
    }
}