using Bussiness.Interfaces.Providers;
using Infra.Providers.Configs;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Configs
{
    public static class DataDependencyInjection
    {
        public static void AdddataDependencies(this IServiceCollection services) {
            services.AddScoped<IHttpService,HttpService>();
        }
    }
}