
using Api.Gateway.Models.seeker.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

using System.Threading.Tasks;

namespace Api.Gateway.Proxies
{
    public interface IOrchestratorProxy
    {
        Task<FacturaCommand> ShopingLogic(DataRequest command);
    }

    public class OrchestratorProxy : IOrchestratorProxy
    {
        // inyeccicon dependencias para los objetos URL y http
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;
        public OrchestratorProxy(
            HttpClient httpClient,
            IOptions<ApiUrls> apiUrls,
            IHttpContextAccessor httpContextAccessor
            )
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }


        public async Task<FacturaCommand> ShopingLogic(DataRequest command)
        {

            var productList = command.Products.ToArray();
            var (subtotal, total, impuesto) = subtotalcalculate(productList);

            Random ram = new Random();
            int ranNum = ram.Next(10000, 100000000);

            // Proceso para enviar un pedido a Lgistica 

            PedidoCommand Pedido = new PedidoCommand();
            for (var i = 0; i < productList.Length; i++) {
            
                    Pedido.idPedido = ranNum;
                    Pedido.idProducto = productList[i].idProducto;
                    Pedido.idCliente = command.DataUser.idUsuario;
                    Pedido.observacion = command.DataFactura.observacion;
                    Pedido.direccion = command.DataFactura.direccion;
                    Pedido.cantidad = productList[i].cantidad;
                    Pedido.estado = command.DataFactura.estado;

                var contenidologistica = new StringContent(System.Text.Json.JsonSerializer.Serialize(Pedido),Encoding.UTF8,"application/json");

                var requestPedido = await _httpClient.PostAsync($"{_apiUrls.PedidosUrl}", contenidologistica);
                string auxJson = await requestPedido.Content.ReadAsStringAsync();
                var jsonSeeker = JsonConvert.DeserializeObject<FacturaCommand>(auxJson);

            }
    



            // Proceso para guardar la Factura y calcular el total de la compra 

            FacturaCommand Factura = new FacturaCommand();
            
            Factura.IdFactura = ranNum;
            Factura.Observacion = command.DataFactura.observacion;
            Factura.Subtotal = subtotal;
            Factura.Fecha = command.DataFactura.fechaFactura;
            Factura.Impuesto = impuesto;
            Factura.Total = total;


            var content = new StringContent(
               System.Text.Json.JsonSerializer.Serialize(Factura),
               Encoding.UTF8,
               "application/json"
           );
                   

            var requestFactura = await _httpClient.PostAsync($"{_apiUrls.FacturasUrl}", content);
            string auxJsonFactura = await requestFactura.Content.ReadAsStringAsync();
            var jsonSeekerFactura = JsonConvert.DeserializeObject<FacturaCommand>(auxJsonFactura);
            return await Task.FromResult(jsonSeekerFactura);

        }

        public static void registrarPedido(IProducts[] productList, int ranNum)
        {
            

        }
        public static (double, double, double) subtotalcalculate(IProducts[] productList) {

            double subtotal = 0;
            double total = 0;
            double valor_unidad = 0;
            double descuento = 0;
            double impuesto = 0;
            int cantidad = 0;
            
            for (var i = 0; i < productList.Length; i++)
            {
                valor_unidad = (double)productList[i].valor_unidad;
                cantidad = productList[i].cantidad;
                descuento = (double)productList[i].descuento;

              
                valor_unidad = valor_unidad - ( valor_unidad * (descuento/100));
                subtotal = subtotal + ( valor_unidad * cantidad );
                
            }
            impuesto = (subtotal * 0.19);
            total = subtotal - impuesto;
            return (subtotal,  total, impuesto);
        
        }
     
    }
}