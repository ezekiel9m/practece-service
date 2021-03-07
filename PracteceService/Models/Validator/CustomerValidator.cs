using FluentValidation;
using PracteceService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracteceService.Models.Validator
{
    public class CustomerValidator : AbstractValidator<Models.Customer.CustomerModel>
    {
        private readonly CustomerService _customerService;

        const string NotNullMessage = "element is required";

        const string NotEmptyMessage = "element cannot be empty";
        public CustomerValidator(CustomerService customerService)
        {
            _customerService = customerService;

            RuleFor(x => x.Name)
               .NotNull().WithErrorCode("400").WithMessage(NotNullMessage)
               .NotEmpty().WithErrorCode("400").WithMessage(NotEmptyMessage);

            RuleFor(x => x.LastName)
                .NotNull().WithErrorCode("400").WithMessage(NotNullMessage)
                .NotEmpty().WithErrorCode("400").WithMessage(NotEmptyMessage);

            RuleFor(x => x.DocumentNumber)
                .NotNull().WithErrorCode("400").WithMessage(NotNullMessage)
                .NotEmpty().WithErrorCode("400").WithMessage(NotEmptyMessage);

            RuleFor(x => x.Email)
                .NotNull().WithErrorCode("400").WithMessage(NotNullMessage)
                .NotEmpty().WithErrorCode("400").WithMessage(NotEmptyMessage)
                .EmailAddress().WithErrorCode("400").WithMessage("invalid email format")
                .Must(x => !IsEmailAvailable(x)).WithErrorCode("400").WithMessage("customer email already exists");

            RuleFor(x => x.Gender)
                .NotNull().WithErrorCode("400").WithMessage(NotNullMessage)
                .NotEmpty().WithErrorCode("400").WithMessage(NotEmptyMessage);
        }

        private bool IsEmailAvailable(string email) => _customerService.IsEmailAvailable(email);
    }
}
