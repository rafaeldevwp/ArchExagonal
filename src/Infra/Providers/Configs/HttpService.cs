using Bussiness.Interfaces.Providers;
using Flurl;
using Flurl.Http;
using Microsoft.VisualBasic;

namespace Infra.Providers.Configs
{
    public class HttpService : IHttpService
    {
        public string BaseUrl { get; set; }
        public AuthParameter authParameter { get; set; }

        public async Task<T> DeleteJsonAsync<T>(string url)
        {
            var response = await GetBaseRequest(BaseUrl).DeleteAsync();
            return await HandleResponse<T>(response);
        }

        public async Task<T> GetJsonAsync<T>(string url)
        {
            var response = await GetBaseRequest(url).GetAsync();
            return await HandleResponse<T>(response);
        }

    
        public async Task<T> PostJsonAsync<T>(string url, object data)
        {
            var response = await GetBaseRequest(BaseUrl).PostJsonAsync(data);
            return await HandleResponse<T>(response);
        }

   
        public async Task<T> PutJsonAsync<T>(string url, object data)
        {
            var response = await GetBaseRequest(BaseUrl).PutJsonAsync(data);
            return await HandleResponse<T>(response);
        }


        private IFlurlRequest GetBaseRequest(string url)
        {
            string flurlUrl;

            if (url.Contains('?'))
                flurlUrl = BaseUrl + url;
            else
                flurlUrl = BaseUrl.AppendPathSegment(url); //todo - implementar;

            var request = flurlUrl.AllowAnyHttpStatus();

            if (authParameter != null && !string.IsNullOrEmpty(authParameter.Type))
            {

                if (!string.IsNullOrEmpty(authParameter.Token))
                    request = request.WithHeader(authParameter.Type, authParameter.Token);
            }
            return request;
        }

        private async Task<T> HandleResponse<T>(IFlurlResponse response)
        {
            if (!response.ResponseMessage.IsSuccessStatusCode)
                throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");

            return await response.GetJsonAsync<T>();
        }

    }

    public class AuthParameter
    {
        public string Type { get; set; }
        public string Token { get; set; }
    }
}
