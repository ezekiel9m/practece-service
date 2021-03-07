using PracteceService.Test.Orderers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PracteceService.Test.API
{
    /// <summary>
    /// Teste de todas das controllers 
    /// </summary>
    [TestCaseOrderer("PracteceService.Test.Orderers.PriorityOrderer", "PracteceService.Test")]
    public class GeneralTests : Service
    {
                
        #region TESTE DA CONTROLLER CUSTOMERS

        /// <summary>
        /// Criação de customer
        /// Teste de successo
        /// Status - created 
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(1)]
        public async Task TestCreateCustomer()
        {
            var customers = new CustomersTest();

            var resp = await customers.CreateCustomer();

            Assert.True(IsValidJson(resp.responseBody), resp.responseBody);

            Assert.Equal(HttpStatusCode.Created, resp.response.StatusCode);
        }

        /// <summary>
        /// Listar customers 
        /// Teste de sucesso 
        /// Staus - Ok
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(2)]
        public async Task TestListCustomer()
        {
            var customers = new CustomersTest();

            var resp = await customers.ListCustomer();

            Assert.True(IsValidJson(resp.responseBody), resp.responseBody);

            Assert.Equal(HttpStatusCode.OK, resp.response.StatusCode);
        }

        /// <summary>
        /// Buscar customers especifico com id
        /// Teste de sucesso 
        /// Staus - Ok
        /// </summary>

        /// <returns></returns>
        [Fact, TestPriority(3)]
        public async Task TestGetCustomerSpecific()
        {
            var customers = new CustomersTest();

            var resp = await customers.GetCustomersSpecific();

            Assert.True(IsValidJson(resp.responseBody), resp.responseBody);

            Assert.Equal(HttpStatusCode.OK, resp.response.StatusCode);
        }

        /// <summary>
        /// Buscar customers especifico com id com errado
        /// Teste de sucesso 
        /// Staus - Ok
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(4)]
        public async Task TestGetCustomer()
        {
            var customers = new CustomersTest();

            var resp = await customers.GetCustomersId();

            Assert.True(IsValidJson(resp.responseBody), resp.responseBody);

            Assert.Equal(HttpStatusCode.NotFound, resp.response.StatusCode);
        }

        /// <summary>
        /// Atualizar de customer
        /// Teste de successo
        /// Status - OK 
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(5)]
        public async Task TestUpdateCustomer()
        {
            var customers = new CustomersTest();

            var resp = await customers.UpdateCustomer();

            Assert.True(IsValidJson(resp.responseBody), resp.responseBody);

            Assert.Equal(HttpStatusCode.OK, resp.response.StatusCode);
        }

        /// <summary>
        /// Excluir customer 
        /// Teste de sucesso
        /// Status NoContent
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(6)]
        public async Task TestDeleteCustomer()
        {
            var customers = new CustomersTest();

            var resp = await customers.DeleteCustomer();

            Assert.Equal(HttpStatusCode.NoContent, resp.response.StatusCode);
        }

        #endregion

        #region TESTE DA CONTROLLER PRODUCT

        /// <summary>
        /// Criação de products
        /// Teste de successo
        /// Status - created 
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(7)]
        public async Task TestCreateProduct()
        {
            var product = new ProductsTest();

            var resp = await product.CreateProduct();

            Assert.True(IsValidJson(resp.responseBody), resp.responseBody);

            Assert.Equal(HttpStatusCode.Created, resp.response.StatusCode);
        }

        /// <summary>
        /// Listar products 
        /// Teste de sucesso 
        /// Staus - Ok
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(8)]
        public async Task TestListProduct()
        {
            var product = new ProductsTest();

            var resp = await product.ListProduct();

            Assert.True(IsValidJson(resp.responseBody), resp.responseBody);

            Assert.Equal(HttpStatusCode.OK, resp.response.StatusCode);
        }

        /// <summary>
        /// Buscar products especifico com id
        /// Teste de sucesso 
        /// Staus - Ok
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(9)]
        public async Task TestGetProductSpecific()
        {
            var product = new ProductsTest();

            var resp = await product.GetProductSpecific();

            Assert.True(IsValidJson(resp.responseBody), resp.responseBody);

            Assert.Equal(HttpStatusCode.OK, resp.response.StatusCode);
        }

        /// <summary>
        /// Buscar products especifico com id com errado
        /// Teste de sucesso 
        /// Staus - Ok
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(10)]
        public async Task TestGetProduct()
        {
            var product = new ProductsTest();

            var resp = await product.GetProductsId();

            Assert.True(IsValidJson(resp.responseBody), resp.responseBody);

            Assert.Equal(HttpStatusCode.NotFound, resp.response.StatusCode);
        }

        /// <summary>
        /// Atualizar de products
        /// Teste de successo
        /// Status - OK 
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(11)]
        public async Task TestUpdateProduct()
        {
            var product = new ProductsTest();

            var resp = await product.UpdateProduct();

            Assert.True(IsValidJson(resp.responseBody), resp.responseBody);

            Assert.Equal(HttpStatusCode.OK, resp.response.StatusCode);
        }

        /// <summary>
        /// Excluir products 
        /// Teste de sucesso
        /// Status NoContent
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(12)]
        public async Task TestDeleteProduct()
        {
            var product = new ProductsTest();

            var resp = await product.DeleteCustomer();

            Assert.Equal(HttpStatusCode.NoContent, resp.response.StatusCode);
        }

        #endregion

        #region TESTE DA CONTROLLER SALE

        /// <summary>
        /// Criação de sales
        /// Teste de successo
        /// Status - created 
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(13)]
        public async Task TestCreateSale()
        {
            var sales = new SalesTeste();

            var resp = await sales.CreateSale();

            Assert.True(IsValidJson(resp.responseBody), resp.responseBody);

            Assert.Equal(HttpStatusCode.Created, resp.response.StatusCode);
        }

        /// <summary>
        /// Listar sales 
        /// Teste de sucesso 
        /// Staus - Ok
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(14)]
        public async Task TestListSales()
        {
            var sales = new SalesTeste();

            var resp = await sales.ListSales();

            Assert.True(IsValidJson(resp.responseBody), resp.responseBody);

            Assert.Equal(HttpStatusCode.OK, resp.response.StatusCode);
        }

        /// <summary>
        /// Buscar sales especifico com id
        /// Teste de sucesso 
        /// Staus - Ok
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(15)]
        public async Task TestGetSaleSpecific()
        {
            var sales = new SalesTeste();

            var resp = await sales.GetSaleSpecific();

            Assert.True(IsValidJson(resp.responseBody), resp.responseBody);

            Assert.Equal(HttpStatusCode.OK, resp.response.StatusCode);
        }

        /// <summary>
        /// Atualizar de sales
        /// Teste de successo
        /// Status - OK 
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(16)]
        public async Task TestUpdateSale()
        {
            var sales = new SalesTeste();

            var resp = await sales.UpdateSale();

            Assert.True(IsValidJson(resp.responseBody), resp.responseBody);

            Assert.Equal(HttpStatusCode.OK, resp.response.StatusCode);
        }

        /// <summary>
        /// Excluir sales 
        /// Teste de sucesso
        /// Status NoContent
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(17)]
        public async Task TestDeleteSale()
        {
            var sales = new SalesTeste();

            var resp = await sales.DeleteSale();

            Assert.Equal(HttpStatusCode.NoContent, resp.response.StatusCode);
        }

        #endregion
    }
}
