using AppTiendaZ.Models;
using AppTiendaZ.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppTiendaZ.Services
{
    public class ApiService<T, Tout> : IApiService<T, Tout>
    {
        private readonly HttpClient httpClient;
        public ApiService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Directions.DirectionsApi.UrlBase);
        }

        public async Task<T> Get(string uri)
        {
            try
            {
                var result = await httpClient.GetAsync(uri);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();

                    var response = JsonConvert.DeserializeObject<T>(content);

                    return response;
                }
                return default;
            }
            catch (Exception ex)
            {
                throw new CommunicationException(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAll(string url)
        {
            try
            {
                try
                {
                    var result = await httpClient.GetAsync(url);

                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var content = await result.Content.ReadAsStringAsync();

                        var response = JsonConvert.DeserializeObject<IEnumerable<T>>(content);

                        return response;
                    }
                    return default;
                }
                catch (Exception ex)
                {
                    throw new CommunicationException(ex.Message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Tout>> GetAll(T entity, string url)
        {
            try
            {
                string json = JsonConvert.SerializeObject(entity);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                // Error here
                var httpResponse = await httpClient.PostAsync(url, httpContent);

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var j = await httpResponse.Content.ReadAsStringAsync();

                    var status = JsonConvert.DeserializeObject<List<Tout>>(j);

                    return status;
                }

                return default;
            }
            catch (Exception ex)
            {
                throw new CommunicationException(ex.Message);
            }

        }


        public async Task<Tout> Post(string uri, T model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await httpClient.PostAsync(uri, content);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contentResponse = await result.Content.ReadAsStringAsync();

                    var response = JsonConvert.DeserializeObject<Tout>(contentResponse);

                    return response;
                }
                return default;
            }
            catch (Exception ex)
            {
                throw new CommunicationException(ex.Message);
            }
        }

        Task<T> IApiPost<T, Tout>.Post(string uri, T model)
        {
            throw new NotImplementedException();
        }
    }
}
