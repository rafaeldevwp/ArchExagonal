using Bussiness.Interfaces.Providers;
using Bussiness.Interfaces.Repository;
using Bussiness.Interfaces.Services;
using Infra.Providers;
using Infra.Providers.Configs;
using Infra.Repository;
using Infra.Services.AlunoServices;
using Infra.Services.Matricula;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infra.Configs
{
    public static class DataDependencyInjection
    {
        public static void AddDataDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IAlunoServices, AlunoServices>();
            services.AddScoped<IMatriculaService, MatriculaService>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
         
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PagSeguroProviderSettings>(opt =>
            {
                opt.BaseUrl = configuration["PagSeguroProviderSettings:BaseUrl"];
                opt.Token =   configuration["PagSeguroProviderSettings:Token"];
                opt.Email =   configuration["PagSeguroProviderSettings:Email"];
                opt.appId =   configuration["PagSeguroProviderSettings:appId"];
                opt.AppKey =  configuration["PagSeguroProviderSettings:AppKey"];

            }).AddSingleton<IPagSeguroProviderSettings>
            (sp => sp.GetRequiredService<IOptions<PagSeguroProviderSettings>>().Value);
        }
    }
}