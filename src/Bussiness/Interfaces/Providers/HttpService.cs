using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bussiness.Interfaces.Providers
{
    public interface HttpService
    {
        Task<HttpContent> Post(HttpClient httpClient);
        Task<HttpContent> Get();
    }
}