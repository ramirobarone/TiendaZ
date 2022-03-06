namespace AppTiendaZ.Directions
{
    public static class DirectionsApi
    {
        private static Enviroment _Enviroment
        {
            get => _Enviroment;
            set
            {
                _Enviroment = Enviroment.Sandbox;
            }
        }


        public const string UrlBase = "https://uat-apiappzenziya.azurewebsites.net";
        public const string InicioSesion = "Login";
        public const string Cuotas = "Cuotas";
        public const string Credito = "Credito";
        public const string Notificaciones = "Notificaciones";
        public const string Cobros = "Cobros";
        public const string PreguntasFrecuentes = "PreguntasFrecuentes";
        public const string Configuraciones = "Configuraciones";
        //Local
        public const string UserData = "UserData";

        public const int Pais = (int)Paises.Dominicana;

        public const string SimboloMoneda = Pais == (int)Paises.Dominicana ? "RD$" : "₡";
    }

    enum Enviroment
    {
        Sandbox,
        Live
    }
    enum Paises
    {
        Argentina,
        CostaRica,
        Dominicana
    }
}
