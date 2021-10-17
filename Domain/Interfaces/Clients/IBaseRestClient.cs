using Domain.Helpers.Settings;
using System.Threading.Tasks;

namespace Domain.Interfaces.Clients
{
    public interface IBaseRestClient
    {
        Task CallAsync(RestClientSettings clientSettings);
        Task<T> CallAsync<T>(RestClientSettings clientSettings) where T : new();
        string GetUrl(string endpoint);
    }
}
