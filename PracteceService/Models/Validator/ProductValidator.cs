using FluentValidation;
using PracteceService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracteceService.Models.Validator
{
    public class ProductValidator : AbstractValidator<Models.Product.ProductModel>
    {
        private readonly ProductService _productService;

        const string NotNullMessage = "element is required";

        const string NotEmptyMessage = "element cannot be empty";
        public ProductValidator(ProductService productService)
        {
            _productService = productService;

            RuleFor(x => x.Name)
               .NotNull().WithErrorCode("400").WithMessage(NotNullMessage)
               .NotEmpty().WithErrorCode("400").WithMessage(NotEmptyMessage);

            When(x => x.Price != 0, () =>
            {
                RuleFor(x => x.Price)
                    .NotNull().WithErrorCode("400").WithMessage(NotNullMessage)
                    .NotEmpty().WithErrorCode("400").WithMessage(NotEmptyMessage)
                    .GreaterThan(0).WithErrorCode("400").WithName("price").WithMessage("price must be greather than 0");
            });

            RuleFor(x => x.Description)
            .MaximumLength(60).WithErrorCode("400").WithMessage("maximum length reached. Max length: 60");
        }
    }
}
