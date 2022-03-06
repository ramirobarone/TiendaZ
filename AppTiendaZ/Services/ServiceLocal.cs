using AppTiendaZ.Services.Interfaces;
using Newtonsoft.Json;


namespace AppTiendaZ.Services
{
    public class ServiceLocal<T> : IServiceLocal<T>
    {
        public void DeleteAccount()
        {
            Xamarin.Essentials.SecureStorage.Remove(Directions.DirectionsApi.UserData);
        }

        public T GetDataSettings(string name)
        {
            var json = Xamarin.Essentials.SecureStorage.GetAsync(name).Result;

            if (json != null)
                return JsonConvert.DeserializeObject<T>(json);
            else
                return default;
        }

        public void SaveDataSettings(string name, T model)
        {
            var json = JsonConvert.SerializeObject(model);
            Xamarin.Essentials.SecureStorage.SetAsync(name, json);
        }
    }
}
