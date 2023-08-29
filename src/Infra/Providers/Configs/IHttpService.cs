using Infra.Providers.Configs;

namespace Bussiness.Interfaces.Providers
{
    public interface IHttpService
    {
        string BaseUrl { get; set; }   
        AuthParameter authParameter { get; set; }  

        Task<T> GetJsonAsync<T>(string url);
       
        Task<T> PostJsonAsync<T>(string url, object data);

        Task<T> PutJsonAsync<T>(string url, object data);

        Task<T> DeleteJsonAsync<T>(string url);


    }
}