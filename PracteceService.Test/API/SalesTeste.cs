using Newtonsoft.Json;
using PracteceService.Test.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PracteceService.Test.API
{

    /// <summary>
    /// Testes da Controller da sales
    /// </summary>
    public class SalesTeste : Service
    {
        private const string prefixPath = "v1/sales";

        /// <summary>
        /// Criação de sales
        /// Teste de successo
        /// Status - created 
        /// </summary>
        /// <returns></returns>
        [Trait("sales", "POST")]
        public async Task<ResponseMessage> CreateSale()
        {
            var body = new PracteceService.Models.Sale.SaleModel();

            body.Customer = new Models.Customer.CustomerModel {CustomerId = "2585dd7b-59d4-4e15-bbd1-8cbb0c96d096" };
            body.Product = new Models.Product.ProductModel { ProductId = 4 };

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
        /// Listar sales 
        /// Teste de sucesso 
        /// Staus - Ok
        /// </summary>
        /// <returns></returns>
        [Trait("sales", "GET")]
        public async Task<ResponseMessage> ListSales()
        {
            var path = $"{prefixPath}";

            var request = await GenerateRequest(HttpMethodCode.GET, path);

            var response = await _client.SendAsync(request);

            string responseBody = await response.Content.ReadAsStringAsync();

            Assert.IsType<List<PracteceService.Models.Sale.SaleModel>>(JsonConvert.DeserializeObject<List<Models.Sale.SaleModel>>(responseBody));

            var result = new ResponseMessage
            {
                response = response,
                responseBody = responseBody
            };

            return result;
        }

        /// <summary>
        /// Buscar sales especifico com id
        /// Teste de sucesso 
        /// Staus - Ok
        /// </summary>
        /// <returns></returns>
        [Trait("sales", "GET")]
        public async Task<ResponseMessage> GetSaleSpecific()
        {
            int saleId = 1;

            var path = $"{prefixPath}/{saleId}";

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
        /// Atualizar de sales
        /// Teste de successo
        /// Status - OK 
        /// </summary>
        /// <returns></returns>
        [Trait("sales", "PUT")]
        public async Task<ResponseMessage> UpdateSale()
        {
            var body = new PracteceService.Models.Sale.SaleModel();

            body.Product = new Models.Product.ProductModel { ProductId = 5};

            int saleId = 2;

            var path = $"{prefixPath}/{saleId}";

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
        /// Excluir sales 
        /// Teste de sucesso
        /// Status NoContent
        /// </summary>
        /// <returns></returns>
        [Trait("sales", "DELETE")]
        public async Task<ResponseMessage> DeleteSale()
        {
            int saleId = 1;

            var path = $"{prefixPath}/{saleId}";

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
