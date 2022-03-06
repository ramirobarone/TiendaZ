using System;
using System.Net.Http;

namespace BilleteraPais.Services
{
    public static class ConfigurationService
    {
        public static HttpClient HttpClient;

        static ConfigurationService()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(AppTiendaZ.Directions.DirectionsApi.UrlBase);
        }

        //public static async Task<ResponseLogin> Login(LoginModel model)
        //{

        //    var request = new HttpRequestMessage()
        //    {
        //        Content = new FormUrlEncodedContent(Headers(model)),
        //        RequestUri = new Uri(AppTiendaZ.Directions.DirectionsApi.UrlBase + "/Login"),
        //        Method = HttpMethod.Post
        //    };

        //    var resultado = await HttpClient.SendAsync(request);

        //    var contentResponse = await resultado.Content.ReadAsStringAsync();
        //    var response = JsonConvert.DeserializeObject<ResponseLogin>(contentResponse);

        //    if (!string.IsNullOrEmpty(response.access_token))
        //    {
        //        return response;
        //    }
        //    else
        //    {
        //        var responseLogin = JsonConvert.DeserializeObject<ErrorLogin>(contentResponse);

        //        throw new CommunicationException(responseLogin.error);
        //    }
        //}

    }
}
