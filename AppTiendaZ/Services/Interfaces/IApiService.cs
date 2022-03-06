using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppTiendaZ.Services.Interfaces
{
    public interface IApiService<T, Tout> : IApiGet<T, Tout>, IApiPost<T, Tout>, IApiGetAll<T, Tout>
    {
    }
    public interface IApiGet<T, Tout>
    {
        Task<T> Get(string uri);

    }
    public interface IApiPost<T, Tout>
    {
        Task<T> Post(string uri, T model);
    }
    public interface IApiGetAll<T, Tout>
    {
        Task<IEnumerable<T>> GetAll(string url);
    }
}