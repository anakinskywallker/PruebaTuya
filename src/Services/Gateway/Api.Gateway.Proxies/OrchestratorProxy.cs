using Api.Gateway.Models.seeker.Commands;
using Api.Gateway.Models.seeker.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;

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
                       
            FacturaCommand Factura = new FacturaCommand();
                       
            Random myObject = new Random();
            int ranNum = myObject.Next(10000, 100000000);

            Factura.IdFactura = ranNum;
            Factura.Observacion = command.DataCompani.observacion;
            Factura.Subtotal = subtotal;
            Factura.Fecha = command.DataCompani.fechaFactura;
            Factura.Impuesto = impuesto;
            Factura.Total = total;

            var content = new StringContent(
               System.Text.Json.JsonSerializer.Serialize(Factura),
               Encoding.UTF8,
               "application/json"
           );
                   

            var request = await _httpClient.PostAsync($"{_apiUrls.FacturasUrl}", content);
            string auxJson = await request.Content.ReadAsStringAsync();
            var jsonSeeker = JsonConvert.DeserializeObject<FacturaCommand>(auxJson);
            return await Task.FromResult(jsonSeeker);

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