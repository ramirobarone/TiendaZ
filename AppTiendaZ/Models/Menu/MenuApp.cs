using Newtonsoft.Json;

namespace AppTiendaZ.Models.Menu
{
    public class MenuApp
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("nombreMenu")]
        public string NameMenu { get; set; }
        public string controller { get; set; }
        public int orden { get; set; }
        public bool visible { get; set; }
        public string Icon { get; set; }
        public int idPais { get; set; }
    }
}
