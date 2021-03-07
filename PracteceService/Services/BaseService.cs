

using Microsoft.EntityFrameworkCore;
using PracteceServicePackage.Context;
using System;
using System.Linq;

namespace PracteceService.Services
{
    public class BaseService
    {
        protected PracteceServicePackage.Context.PracteceContext recurContext;

        public BaseService(PracteceContext context)
        {
            this.recurContext = context;
        }

        public bool CheckStatus(string customerId = null, int productId = 0)
        {
            bool status = false;

            if (customerId != null)
                status = recurContext.Customer.Find(customerId).IsActive;
            if (productId != 0)
                status = recurContext.Product.Find(productId).IsActive;

            return status;
        }
    }
}
