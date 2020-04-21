using System;
using System.Collections.Generic;
using System.Text;

namespace fnc_PedidosYadb.NewFolder1
{
    using Newtonsoft.Json;
   public class Pedido
    {
        [JsonProperty("idpedido")]
        public string Idpedido { get; set; }
        [JsonProperty("producto")]
        public string Producto { get; set; }
        [JsonProperty("tienda")]
        public string Tienda { get; set; }
        [JsonProperty("cantidad")]
        public string Cantidad { get; set; }
        [JsonProperty("direccion")]
        public string Direccion { get; set; }

        [JsonProperty("idestado")]
        public string Idestado { get; set; }

        [JsonProperty("idempleado")]
        public string Idempleado { get; set; }
    }
}
