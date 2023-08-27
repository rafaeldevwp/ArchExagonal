using Bussiness.Interfaces.Providers;
using Flurl.Http;

namespace Infra.Providers.Configs
{
    public class HttpService<T> : IHttpService<T>
    {
        public async Task<T> DeleteJsonAsync(string url)
        {
            return await url.DeleteAsync().ReceiveJson<T>();
        }

        public async Task<T> DeleteJsonAsync(string url, object headers)
        {
            var flurlRequest = new FlurlRequest(url).WithHeaders(headers);
            return await flurlRequest.DeleteAsync().ReceiveJson<T>();
        }

        public async Task<T> GetJsonAsync(string url)
        {
            return await url.GetJsonAsync<T>();
        }

        public async Task<T> GetJsonAsync(string url, object queryParams)
        {
            return await new FlurlRequest(url).SetQueryParams(queryParams).GetJsonAsync<T>();
        }

        public async Task<T> GetJsonAsync(string url, object queryParams, object headers)
        {
            return await new FlurlRequest(url).SetQueryParams(queryParams).WithHeaders(headers).GetJsonAsync<T>();
        }

        public async Task<T> PostJsonAsync(string url, object data)
        {
            return await url.PostJsonAsync(data).ReceiveJson<T>();
        }

        public async Task<T> PostJsonAsync(string url, object data, object headers)
        {
            return await new FlurlRequest(url).WithHeaders(headers).PostJsonAsync(data).ReceiveJson<T>();
        }

        public async Task<T> PutJsonAsync(string url, object data)
        {
            return await url.PutAsync().ReceiveJson<T>();
        }

        public async Task<T> PutJsonAsync(string url, object data, object headers)
        {
            return await new FlurlRequest(url).WithHeaders(headers).PutJsonAsync(data).ReceiveJson<T>();
        }
    }
}
