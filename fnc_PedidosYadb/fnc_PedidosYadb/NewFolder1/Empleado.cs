
namespace fnc_PedidosYadb.NewFolder1
{
    using Newtonsoft.Json;
    public class Empleado
    {
        [JsonProperty("idempleado")]
        public string Idempleado { get; set; }
        [JsonProperty("name")]
        public string Nombre { get; set; }
        [JsonProperty("telefono")]
        public string Telefono { get; set; }
        [JsonProperty("idestado")]
        public string Idestado { get; set; }
       
    }
}
