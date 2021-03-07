using Newtonsoft.Json;
using PracteceService.Test.Helper;
using PracteceService.Test.Orderers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PracteceService.Test.API
{
    /// <summary>
    /// Testes da Controller da customer
    /// </summary>
    public class CustomersTest : Service
    {
        private const string prefixPath = "v1/customers";

        /// <summary>
        /// Criação de customer
        /// Teste de successo
        /// Status - created 
        /// </summary>
        /// <returns></returns>
        [Trait("customers", "POST")]
        public async Task<ResponseMessage> CreateCustomer()
        {
            var x = PracteceService.Helpers.GeneratorCode.CreatorCode(2, true);

            var body = new Models.Customer.CustomerModel
            {
                Name = "Pedro",
                LastName = "Tomás",
                DocumentNumber = $"685.920.250-{x}",
                PhoneNumebr = $"1195190-87{x}",
                Gender = "M",
                Email = $"pedro.tomas{x}@gmail.com",
                BirthDate = DateTime.UtcNow.AddYears(-10),
            };

            var path = $"{prefixPath}";

            var request = await GenerateRequest(HttpMethodCode.POST, path, body);

            var response = await _client.SendAsync(request);

            string responseBody = await response.Content.ReadAsStringAsync();

            var result = new ResponseMessage
            {
                response = response,
                responseBody = responseBody
            };

            return result;
        }

        /// <summary>
        /// Listar customers 
        /// Teste de sucesso 
        /// Staus - Ok
        /// </summary>
        /// <returns></returns>
        [Trait("customers", "GET")]
        public async Task<ResponseMessage> ListCustomer()
        {
            var path = $"{prefixPath}";

            var request = await GenerateRequest(HttpMethodCode.GET, path);

            var response = await _client.SendAsync(request);

            string responseBody = await response.Content.ReadAsStringAsync();

            Assert.IsType<List<PracteceService.Models.Customer.CustomerModel>>(JsonConvert.DeserializeObject<List<Models.Customer.CustomerModel>>(responseBody));

            var result = new ResponseMessage
            {
                response = response,
                responseBody = responseBody
            };

            return result;
        }

        /// <summary>
        /// listar customers especifico com id
        /// Teste de sucesso 
        /// Staus - Ok
        /// </summary>
        /// <returns></returns>
        [Trait("customers", "GET")]
        public async Task<ResponseMessage> GetCustomersSpecific()
        {
            var customerId = "27133bbe-7a5b-4407-88ab-2c1d99539429";

            var path = $"{prefixPath}/{customerId}";

            var request = await GenerateRequest(HttpMethodCode.GET, path);

            var response = await _client.SendAsync(request);

            string responseBody = await response.Content.ReadAsStringAsync();

            var result = new ResponseMessage
            {
                response = response,
                responseBody = responseBody
            };

            return result;
        }

        /// <summary>
        /// Buscar customers especifico com id errado
        /// Teste de erro 
        /// Staus - NotFound
        /// </summary>
        /// <returns></returns>
        [Trait("customers", "GET")]
        public async Task<ResponseMessage> GetCustomersId()
        {
            var customerId = "eb0c090f-a1cf-49a1-9936-8e0224b0dc3bsb";

            var path = $"{prefixPath}/{customerId}";

            var request = await GenerateRequest(HttpMethodCode.GET, path);

            var response = await _client.SendAsync(request);

            string responseBody = await response.Content.ReadAsStringAsync();

            var result = new ResponseMessage
            {
                response = response,
                responseBody = responseBody
            };

            return result;
        }

        /// <summary>
        /// Atualizar de customer
        /// Teste de successo
        /// Status - OK 
        /// </summary>
        /// <returns></returns>
        [Trait("customers", "PUT")]
        public async Task<ResponseMessage> UpdateCustomer()
        {
            
            var x = PracteceService.Helpers.GeneratorCode.CreatorCode(2, true);

            var body = new Models.Customer.CustomerModel
            {
                Name = "Willan",
                LastName = "da Costa",
                DocumentNumber = $"685.920.250-{x}",
                PhoneNumebr = $"1195190-87{x}",
                Email = $"willan.costa@tecm.com"
            };

            var customerId = "2585dd7b-59d4-4e15-bbd1-8cbb0c96d096";

            var path = $"{prefixPath}/{customerId}";

            var request = await GenerateRequest(HttpMethodCode.PUT, path, body);

            var response = await _client.SendAsync(request);

            string responseBody = await response.Content.ReadAsStringAsync();

            var result = new ResponseMessage
            {
                response = response,
                responseBody = responseBody
            };

            return result;
        }

        /// <summary>
        /// Excluir customer 
        /// Teste de sucesso
        /// Status NoContent
        /// </summary>
        /// <returns></returns>
        [Trait("customers", "DELETE")]
        public async Task<ResponseMessage> DeleteCustomer()
        {
            var customerId = "376e9d0e-108b-4794-9a17-195c7bcb7b27";

            var path = $"{prefixPath}/{customerId}";

            var request = await GenerateRequest(HttpMethodCode.DELETE, path);

            var response = await _client.SendAsync(request);

            var result = new ResponseMessage
            {
                response = response
            };

            return result;
        }
    }


}
