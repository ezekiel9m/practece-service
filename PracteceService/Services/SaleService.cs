using Microsoft.EntityFrameworkCore;
using PracteceServicePackage.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecmExceptions;

namespace PracteceService.Services
{
    public class SaleService : BaseService
    {
        public SaleService(PracteceContext context) : base(context)
        {

        }

        public List<Sale> ListSales()
        {
            var sale = recurContext.Sale
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Include(x => x.SaleStatus)
                .ToList();

            return sale;
        }

        public async Task<Sale> GetSaleSpecific(int saleId)
        {
            var sale = recurContext.Sale
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Include(x => x.SaleStatus)
                .FirstOrDefault(x => x.Id == saleId);

            if (sale == null)
            {
                throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                {
                    ErrorCode = 404,
                    ParameterName = "sale_id",
                    Message = "sale not found"
                });
            }

            return sale;
        }

        public async Task<Sale> CreateSale(Models.Sale.SaleModel model)
        {
            var customer = recurContext.Customer
                .AsNoTracking()
                .FirstOrDefault(x => x.CustomerId == model.Customer.CustomerId);

            if (customer == null)
            {
                throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                {
                    ErrorCode = 404,
                    ParameterName = "customer_id",
                    Message = "customer not found"
                });
            }

            var product = recurContext.Product.AsNoTracking().FirstOrDefault(x => x.ProductId == model.Product.ProductId);

            if (product == null)
            {
                throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                {
                    ErrorCode = 404,
                    ParameterName = "product_id",
                    Message = "product not found"
                });
            }


            var sale = new Sale
            {
                Code = Helpers.GeneratorCode.CreatorCode(10),
                BillingDate = DateTime.UtcNow,
                Amount = product.Price,
                TotalAmount = product.Price * 1,
                CustomerName = customer.Name + " " + customer.LastName,
                CustomerId = customer.CustomerId,
                ProductId = product.ProductId,
                CreateDate = DateTime.UtcNow,
                SaleStatusId = recurContext.SaleStatus.FirstOrDefault(x => x.Code.ToLower() == "paid").SaleStatusId
            };

            recurContext.Add(sale);

            recurContext.SaveChanges();

            return sale;
        }

        public async Task<Sale> UpdateSale(Models.Sale.SaleModel saleModel, int saleId)
        {
            var sale = recurContext.Sale
                 .AsNoTracking()
                 .Include(x => x.Customer)
                 .Include(x => x.Product)
                 .Include(x => x.SaleStatus)
                 .FirstOrDefault(x => x.Id == saleId);

            if (sale == null)
            {
                throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                {
                    ErrorCode = 404,
                    ParameterName = "sale_id",
                    Message = "sale not found"
                });
            }

            var product = recurContext.Product.AsNoTracking().FirstOrDefault(x => x.ProductId == sale.ProductId);

            if(product.ProductId != saleModel.Product.ProductId)
            {
                var p = recurContext.Product.AsNoTracking().FirstOrDefault(x => x.ProductId == saleModel.Product.ProductId);

                sale.ProductId = p.ProductId;
                sale.Amount = p.Price;
                sale.TotalAmount = p.Price * 1;
            }

            sale.UpdateDate = DateTime.UtcNow;

            recurContext.SaveChanges();

            return sale;
        }

        public async Task DeleteSale(int saleId)
        {
            var sale = recurContext.Sale.FirstOrDefault(x => x.Id == saleId);

            if (sale == null)
            {
                throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                {
                    ErrorCode = 404,
                    ParameterName = "sale_id",
                    Message = "sale not found"
                });
            }

            recurContext.Remove(sale);

            recurContext.SaveChanges();
        }

        public async Task DeleteProductSale(int productId)
        {
            var saleList = recurContext.Sale.Where(x => x.ProductId == productId).ToList();

            if (saleList != null)
            {
                foreach (var y in saleList)
                {
                    recurContext.Remove(y);
                }

                recurContext.SaveChanges();
            }
        }
    }
}
