using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracteceService.Mappings
{
    public class ProductMap
    {
        public static Models.Product.ProductModel Mapping(PracteceServicePackage.Context.Product product)
        {
            var response = new Models.Product.ProductModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Code = product.Code,
                Description = product.Description,
                Price = product.Price,
                CreateDate = product.CreateDate,
                UpdateDate = product.UpdateDate,
                IsActive = product.IsActive
            };

            return response;
        }
    }
}
