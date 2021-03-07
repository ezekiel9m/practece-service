using Microsoft.EntityFrameworkCore;
using PracteceServicePackage.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TecmExceptions;

namespace PracteceService.Services
{
    public class ProductService : BaseService
    {
        public ProductService(PracteceContext context) : base(context)
        {

        }

        public  List<Product> ListProduct() => recurContext.Product.AsNoTracking().ToList();

        public async Task<Product> GetProductSpecific(int id)
        {
            var product = recurContext.Product
                .AsNoTracking()
                .FirstOrDefault(x => x.ProductId == id);

            if (product == null)
            {
                throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                {
                    ErrorCode = (int)HttpStatusCode.NotFound,
                    ParameterName = "product_id",
                    Message = "product not found"
                });
            }

            return product;
        }

        public async Task<Product> CreateProduct(Models.Product.ProductModel model)
        {
            var product = new Product
            {
                Code = Helpers.GeneratorCode.CreatorCode(10),
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CreateDate = DateTime.UtcNow,
                IsActive = true
            };

            recurContext.Add(product);

            recurContext.SaveChanges();

            return product;
        }

        public async Task<Product> UpdateProduct(Models.Product.ProductModel model, int productId)
        {
            var product = recurContext.Product
                .FirstOrDefault(x => x.ProductId == productId);

            if (product == null)
            {
                throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                {
                    ErrorCode = (int)HttpStatusCode.NotFound,
                    ParameterName = "product_id",
                    Message = "product not found"
                });
            }

            if (!string.IsNullOrEmpty(model.Name))
                product.Name = model.Name;

            if (!string.IsNullOrEmpty(model.Description))
                product.Description = model.Description;

            if (model.Price != 0)
                product.Price = model.Price;

            if (model.IsActive != CheckStatus(null, model.ProductId))
                product.IsActive = model.IsActive;

            product.UpdateDate = DateTime.UtcNow;

            recurContext.SaveChanges();

            return product;
        }

        public async Task DeleteProduct(int productId)
        {
   
            var product = recurContext.Product
               .FirstOrDefault(x => x.ProductId == productId);

            if (product == null)
            {
                throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                {
                    ErrorCode = (int)HttpStatusCode.NotFound,
                    ParameterName = "product_id",
                    Message = "product not found"
                });
            }

            recurContext.Remove(product);

            recurContext.SaveChanges();
        }
    }
}
