using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracteceService.Mappings
{
    public class CustomerMap
    {
        public static Models.Customer.CustomerModel Mapping(PracteceServicePackage.Context.Customer customer)
        {
            var response = new Models.Customer.CustomerModel
            {
                CustomerId = customer.CustomerId,
                Code = customer.Code,
                Name = customer.Name,
                LastName = customer.LastName,
                Email = customer.Email,
                DocumentNumber = customer.DocumentNumber,
                PhoneNumebr = customer.PhoneNumebr,
                Gender = customer.Gender,
                CreateDate = customer.CreateDate,
                UpdateDate = customer.UpdateDate,
                BirthDate = customer.BirthDate,
                Age = customer.Age,
                IsActive = customer.IsActive
            };

            return response;
        }
    }
}
