using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMB.App.Services
{
    public interface IHTTPClient
    {
        Task<T> ExecutePostAsync<T>(string url, Dictionary<string, string> customHeaders = null, bool retry = true);
        Task<T> ExecutePostAsync<T>(string url, Dictionary<string, string> customHeaders = null, string accessToken = null, bool retry = true);
    }
}
