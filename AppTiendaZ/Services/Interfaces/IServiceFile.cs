using System.Threading.Tasks;

namespace AppTiendaZ.Services.Interfaces
{
    public interface IServiceFile
    {
        Task<bool> DownloadFile();
    }
}
