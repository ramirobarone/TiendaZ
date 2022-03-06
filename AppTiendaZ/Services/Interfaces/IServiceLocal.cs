namespace AppTiendaZ.Services.Interfaces
{
    interface IServiceLocal<T>
    {
        void SaveDataSettings(string name, T model);

        T GetDataSettings(string name);

        void DeleteAccount();
    }
}
