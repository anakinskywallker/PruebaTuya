using Api.Gateway.Models.seeker.Commands;
using Api.Gateway.Models.seeker.DTOs;
using Api.Gateway.Services.Commands;
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
        Task<List<CasCreateCommand>> GetOnlySeeker(CasSeekerCommandProxies command);
        Task<CaRepositoryDto> GetAsync(int id);
        Task CreateAsync(CasCreateCommand command);
      //  Task<CasCreateCommand> CAsLogic(CasSeekerCommandProxies command);
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

        public async Task<List<CasCreateCommand>> GetOnlySeeker(CasSeekerCommandProxies command)
        {
            var content = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request1 = await _httpClient.PostAsync($"{_apiUrls.SeekerUrl}", content);
            string auxJson = await request1.Content.ReadAsStringAsync();
            var jsonSeeker = JsonConvert.DeserializeObject<List<CasCreateCommand>>(auxJson);
            return await Task.FromResult(jsonSeeker);
        }

        public async Task<CaRepositoryDto> GetAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.SeekerUrl}Cas/{id}");
            request.EnsureSuccessStatusCode();

            return System.Text.Json.JsonSerializer.Deserialize<CaRepositoryDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task CreateAsync(CasCreateCommand command)
        {
            var content = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiUrls.SeekerUrl}Cas", content);
            request.EnsureSuccessStatusCode();
        }

        //public async Task<CasCreateCommand> CAsLogic(CasSeekerCommandProxies command)
        
/*
            var content = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(command),
                Encoding.UTF8,
                "application/json"
            );
            var request1 = await _httpClient.PostAsync($"{_apiUrls.SeekerUrl}", content);
            string auxJson = await request1.Content.ReadAsStringAsync();
            var jsonSeeker = JsonConvert.DeserializeObject<List<CasCreateCommand>>(auxJson);

            if (jsonSeeker.Count < 1)
            {
                return null;
            }
            else
            {
                if (jsonSeeker[0].Alphabet == command.Alphabet && jsonSeeker[0].Columns == command.Columns)
                {
                   // var varDictionary = new DictionaryModel()
                    {
                        Columns = Int32.Parse(jsonSeeker[0].Columns.ToString()),
                        Strength = Int32.Parse(jsonSeeker[0].Strength.ToString()),
                        Alphabet = jsonSeeker[0].Alphabet.ToString(),
                        TarjetAlphabet = command.Alphabet_user.ToString(),
                        Rows = Int32.Parse(jsonSeeker[0].Rows.ToString()),
                        CA_notes = jsonSeeker[0].CA_notes.ToString()
                    };

                    var req2 = await Dictionary(varDictionary);

                    jsonSeeker[0].CA_notes = req2.CA_notes;


                    return jsonSeeker[0];
                }
                else
                {
                    dynamic jsonObj = JsonConvert.DeserializeObject(auxJson);
                    var commandOpt = new CasOptCommandSeeker()
                    {
                        CAID = Int32.Parse(jsonObj[0]["caid"].ToString()),
                        Columns = Int32.Parse(jsonObj[0]["columns"].ToString()),
                        Strength = command.Strength,
                        //Strength = Int32.Parse(jsonObj[0]["strength"].ToString()),
                        Alphabet = jsonObj[0]["alphabet"].ToString(),
                        Rows = Int32.Parse(jsonObj[0]["rows"].ToString()),
                        CA_notes = jsonObj[0]["cA_notes"].ToString(),

                        TarjetAlphabet = command.Alphabet.ToString(),
                        TarjetColumns = command.Columns,
                    };

                    //DictionaryModel com = new DictionaryModel();
                    //com.Columns = 


                    var contentOpt = new StringContent(
                     System.Text.Json.JsonSerializer.Serialize(commandOpt),
                    Encoding.UTF8,
                    "application/json"
                    );

                    var request2 = await _httpClient.PostAsync($"{_apiUrls.OptimizerUrl}Optimizer", contentOpt);
                    string auxJson2 = await request2.Content.ReadAsStringAsync();
                    var jsonOpt2 = new CasCreateCommand();
                    var varDictionary = new DictionaryModel();
                    if (auxJson2 == "")
                    {

                        varDictionary.Columns = Int32.Parse(jsonSeeker[0].Columns.ToString());
                        varDictionary.Strength = Int32.Parse(jsonSeeker[0].Strength.ToString());
                        varDictionary.Alphabet = jsonSeeker[0].Alphabet.ToString();
                        varDictionary.TarjetAlphabet = command.Alphabet_user.ToString();
                        varDictionary.Rows = Int32.Parse(jsonSeeker[0].Rows.ToString());
                        varDictionary.CA_notes = jsonSeeker[0].CA_notes.ToString();
                    }
                    else
                    {
                        jsonOpt2 = JsonConvert.DeserializeObject<CasCreateCommand>(auxJson2);
                        varDictionary.Columns = Int32.Parse(jsonOpt2.Columns.ToString());
                        varDictionary.Strength = Int32.Parse(jsonOpt2.Strength.ToString());
                        varDictionary.Alphabet = jsonOpt2.Alphabet.ToString();
                        varDictionary.TarjetAlphabet = command.Alphabet_user.ToString();
                        varDictionary.Rows = Int32.Parse(jsonOpt2.Rows.ToString());
                        varDictionary.CA_notes = jsonOpt2.CA_notes.ToString();
                        
                    }

                    var req2 = await Dictionary(varDictionary);
                    jsonOpt2.Alphabet = req2.TarjetAlphabet;
                    jsonOpt2.CA_notes = req2.CA_notes;

                    //return jsonSeeker[0];

                    //var jsonOpt = JsonConvert.DeserializeObject<List<CasCreateCommand>>(auxJson2);
                    return await Task.FromResult(jsonOpt2);

                }
            }
*/
        

        
        
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