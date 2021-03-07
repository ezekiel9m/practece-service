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
    /// Testes da Controller da product
    /// </summary>
    public class ProductsTest : Service
    {
        private const string prefixPath = "v1/products";

        /// <summary>
        /// Criação de product
        /// Teste de successo
        /// Status - created 
        /// </summary>
        /// <returns></returns>
        [Trait("products", "POST")]
        public async Task<ResponseMessage> CreateProduct()
        {
            var name = PracteceService.Helpers.GeneratorCode.CreatorCode(false);
            var price = PracteceService.Helpers.GeneratorCode.CreatorCode(true);

            var body = new PracteceService.Models.Product.ProductModel
            {
                Name = name,
                Price = decimal.Parse(price),
                Description = "Dispositivo electronico",
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
        /// Listar products 
        /// Teste de sucesso 
        /// Staus - Ok
        /// </summary>
        /// <returns></returns>
        [Trait("products", "GET")]
        public async Task<ResponseMessage> ListProduct()
        {
            var path = $"{prefixPath}";

            var request = await GenerateRequest(HttpMethodCode.GET, path);

            var response = await _client.SendAsync(request);

            string responseBody = await response.Content.ReadAsStringAsync();

            Assert.IsType<List<PracteceService.Models.Product.ProductModel>>(JsonConvert.DeserializeObject<List<Models.Product.ProductModel>>(responseBody));

            var result = new ResponseMessage
            {
                response = response,
                responseBody = responseBody
            };

            return result;
        }

        /// <summary>
        /// Buscar product especifico com id
        /// Teste de sucesso 
        /// Staus - Ok
        /// </summary>
        /// <returns></returns>
        [Trait("products", "GET")]
        public async Task<ResponseMessage> GetProductSpecific()
        {
            int productId = 4;

            var path = $"{prefixPath}/{productId}";

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
        /// Buscar product especifico com id errado
        /// Teste de erro 
        /// Staus - NotFound
        /// </summary>
        /// <returns></returns>
        [Trait("products", "GET")]
        public async Task<ResponseMessage> GetProductsId()
        {
            int productId = 21;

            var path = $"{prefixPath}/{productId}";

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
        /// Atualizar de product
        /// Teste de successo
        /// Status - OK 
        /// </summary>
        /// <returns></returns>
        [Trait("products", "PUT")]
        public async Task<ResponseMessage> UpdateProduct()
        {
            var name = PracteceService.Helpers.GeneratorCode.CreatorCode(false);
            var price = PracteceService.Helpers.GeneratorCode.CreatorCode(true);

            var body = new PracteceService.Models.Product.ProductModel
            {
                Name = name,
                Price = decimal.Parse(price)
            };

            var productId = 3;

            var path = $"{prefixPath}/{productId}";

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
        /// Excluir product 
        /// Teste de sucesso
        /// Status NoContent
        /// </summary>
        /// <returns></returns>
        [Trait("products", "DELETE")]
        public async Task<ResponseMessage> DeleteCustomer()
        {
            var productId = 1;

            var path = $"{prefixPath}/{productId}";

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
