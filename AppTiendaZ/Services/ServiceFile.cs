using AppTiendaZ.Services.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AppTiendaZ.Services
{
    public class ServiceFile : IServiceFile
    {

        private string _NombreArchivo = string.Empty;
        private string _Url;

        public ServiceFile(string nombreArchivo, string url)
        {
            this._Url = url;
            _NombreArchivo = nombreArchivo;
        }

        public async Task<bool> DownloadFile()
        {
            try
            {
                WebClient webClient = new WebClient();

                webClient.DownloadDataAsync(new Uri(_Url));

                webClient.DownloadDataCompleted += WebClient_DownloadDataCompleted;

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void WebClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            byte[] file = e.Result;

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string localFilename = $"{_NombreArchivo}.pdf";
            File.WriteAllBytes(Path.Combine(documentsPath, localFilename), file);
        }
    }
}
