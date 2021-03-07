
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracteceServicePackage.Context;
using TecmExceptions;

namespace PracteceService.Services
{
    public class CustomerService : BaseService
    {
        public CustomerService(PracteceContext context) : base(context)
        {

        }

        public List<Customer> GetCustomer() => recurContext.Customer.AsNoTracking().ToList();

        public async Task<Customer> GetCustomerSpecific(string customerId)
        {
            var customer = recurContext.Customer
                .AsNoTracking()
                .FirstOrDefault(x => x.CustomerId == customerId);

           if (customer == null)
           {
                throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                {
                    ErrorCode = (int)HttpStatusCode.NotFound,
                    ParameterName = "customer_id",
                    Message = "customer not found"
                });
           }

            return customer;
        }

        public bool IsEmailAvailable(string email) => recurContext.Customer.AsNoTracking().Any(x => x.Email.ToLower() == email.ToLower());

        public async Task<Customer> CreateCustomer(Models.Customer.CustomerModel model)
        {
            var customer = new Customer
            {
                CustomerId = Guid.NewGuid().ToString(),
                Name = model.Name,
                LastName = model.LastName,
                DocumentNumber = model.DocumentNumber,
                PhoneNumebr = model.PhoneNumebr,
                Email = model.Email,
                Gender = model.Gender,
                CreateDate = DateTime.UtcNow,
                BirthDate = model.BirthDate,
                Age = (DateTime.UtcNow.Year - model.BirthDate.Value.Year),
                IsActive = true
            };

            recurContext.Add(customer);
            recurContext.SaveChanges();

            return customer;
        }

        public async Task<Customer> UpdateCustomer(Models.Customer.CustomerModel model, string customerId)
        {

            var customer = recurContext.Customer.FirstOrDefault(x => x.CustomerId == customerId);

            if (customer == null)
            {
                throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                {
                    ErrorCode = (int)HttpStatusCode.NotFound,
                    ParameterName = "customer_id",
                    Message = "customer not found"
                });
            }


            if (!string.IsNullOrEmpty(model.Name))
                customer.Name = model.Name;

            if (!string.IsNullOrEmpty(model.LastName))
                customer.LastName = model.LastName;

            if (!string.IsNullOrEmpty(model.PhoneNumebr))
                customer.PhoneNumebr = model.PhoneNumebr;

            if (!string.IsNullOrEmpty(model.DocumentNumber))
                customer.DocumentNumber = model.DocumentNumber;

            if (!string.IsNullOrEmpty(model.Email))
                customer.Email = model.Email;

            if (!string.IsNullOrEmpty(model.Gender))
                customer.Gender = model.Gender;

            if (model.IsActive != CheckStatus(customer.CustomerId))
                customer.IsActive = model.IsActive;

            customer.UpdateDate = DateTime.UtcNow;
            recurContext.SaveChanges();

            return customer;
        }

        public async Task DeleteCustomer(string customerId)
        {
            var customer = recurContext.Customer.FirstOrDefault(x => x.CustomerId == customerId);

            if (customer == null)
            {
                throw new TecmErrorException(new TecmExceptions.Models.ErrorModel
                {
                    ErrorCode = (int)HttpStatusCode.NotFound,
                    ParameterName = "customer_id",
                    Message = "customer not found"
                });
            }

            var sale = recurContext.Sale.Where(x => x.CustomerId == customer.CustomerId).ToList();

            if (sale != null)
            {
                foreach (var i in sale)
                {
                    recurContext.Remove(i);
                }

                recurContext.SaveChanges();
            }


            recurContext.Remove(customer);

            recurContext.SaveChanges();
        }
    }
}
