namespace Bussiness.Interfaces.Providers
{
    public interface IHttpService<T>
    {

        Task<T> GetJsonAsync(string url);
        Task<T> GetJsonAsync(string url, object queryParams);
        Task<T> GetJsonAsync(string url, object queryParams, object headers);
        Task<T> PostJsonAsync(string url, object data);
        Task<T> PostJsonAsync(string url, object data, object headers);

        Task<T> PutJsonAsync(string url, object data);
        Task<T> PutJsonAsync(string url, object data, object headers);

        Task<T> DeleteJsonAsync(string url);
        Task<T> DeleteJsonAsync(string url, object headers);

    }
}