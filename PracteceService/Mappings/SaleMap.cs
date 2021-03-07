using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracteceService.Mappings
{
    public class SaleMap
    {
        public static Models.Sale.SaleModel Mapping(PracteceServicePackage.Context.Sale sale)
        {
            var response = new Models.Sale.SaleModel
            {
                Id = sale.Id,
                Code = sale.Code,
                BillingDate = sale.BillingDate,
                Amount = sale.Amount,
                TotalAmount = sale.TotalAmount,
                Status = sale.SaleStatus.Name,
                CreateDate = sale.CreateDate,
                UpdateDate = sale.UpdateDate
            };

            if (sale.Customer != null)
                response.Customer = Mappings.CustomerMap.Mapping(sale.Customer);

            if (sale.Product != null)
                response.Product = Mappings.ProductMap.Mapping(sale.Product);

            return response;
        }
    }
}
