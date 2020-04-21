

namespace fnc_PedidosYadb
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
   
    using Microsoft.Azure.Management.CosmosDB.Fluent;
    public static class PreparaPedido
    {
        [FunctionName(nameof(PreparaPedido))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [CosmosDB(
            databaseName : Constants.COSMOS_DB_DATABASE_NAME,
            collectionName:Constants.COSMOS_DB_CONTAINER_NAME,
            ConnectionStringSetting="StrCosmos"
            )]IAsyncCollector<object>pedidos,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            IActionResult returnValue = null;
            try
            {

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<Pedidos>(requestBody);
                var Pedido = new Pedidos
                {
                    Idpedido = data.Idpedido,
                    Producto = data.Producto,
                    Tienda = data.Tienda,
                    Cantidad = data.Cantidad,
                    Direccion = data.Direccion,
                    Idestado = data.Idestado,
                    Idempleado=data.Idempleado


                };
                await pedidos.AddAsync(Pedido);
                log.LogInformation("Product Inserted {}");
                string responseMessage = Pedido.Producto;
                returnValue = new OkObjectResult(Pedido);
            }
            catch (Exception ex)
            {
                log.LogError($"couldnt insert product :{ex.Message}");
                returnValue = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return returnValue;

        }
    }
}