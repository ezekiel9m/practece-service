using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PracteceService.Helpers;
using PracteceService.Test.Helper;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PracteceService.Test
{
    public class Service 
    {
        /// <summary>
        /// Client do server de testes
        /// </summary>
        protected readonly HttpClient _client;
       
        public Service()
        {
            var server = new TestServer(new WebHostBuilder().UseEnvironment("Development").UseStartup<Startup>());

            _client = server.CreateClient();
        }

        /// <summary>
        /// Método para gerar o Request com objeto do Body para o Test Client
        /// </summary>
        /// <param name="method">Método HTTP</param>
        /// <param name="path">Caminho da API</param>
        /// <example> v1/customers </example>
        /// <param name="body">Objeto para o body, será convertido em JSON. Ficar atento com JsonProperties</param>
        /// <returns>Retorna o HttpRequestMessage para _client.SendAsync()</returns>
        protected async Task<HttpRequestMessage> GenerateRequest(HttpMethodCode method, string path, object body)
        {
            var json = JsonConvert.SerializeObject(body);

            var content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(new HttpMethod(method.Code), path);

            request.Content = content;

            return request;
        }

        /// <summary>
        /// Método para gerar o Request Simples para o Test Client
        /// </summary>
        /// <param name="method">Método HTTP</param>
        /// <param name="path">Caminho da API</param>
        /// <example> v1/customers </example>
        /// <returns></returns>
        protected async Task<HttpRequestMessage> GenerateRequest(HttpMethodCode method, string path)
        {
            var request = new HttpRequestMessage(new HttpMethod(method.Code), path);

            return request;
        }

        /// <summary>
        /// Método para verificação se o JSON é valido
        /// </summary>
        /// <param name="strInput">json para validar</param>
        /// <returns>Retorna o HttpRequestMessage para _client.SendAsync()</returns>
        protected static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) ||
                (strInput.StartsWith("[") && strInput.EndsWith("]")))
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
