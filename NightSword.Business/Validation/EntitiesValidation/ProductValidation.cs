using FluentValidation;
using NightSword.Associate.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Business.Validation.EntitiesValidation
{
    public class ProductValidation : AbstractValidator<ProductDto>
    {
        public ProductValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("This fields cannot be empty..!").MinimumLength(2).WithMessage("Minumum Length is 2");
            RuleFor(x => x.Description).NotEmpty().WithMessage("This fields cannot be empty..!").MinimumLength(2).WithMessage("Minumum Length is 2");
            RuleFor(x => x.Price).NotEmpty().WithMessage("This fields cannot be empty..!").GreaterThan(0).WithMessage("Ürün fiyatı 5'ten fazla olmalıdır");
            RuleFor(x => x.CategoryId).NotNull().WithMessage("Please Choose A Category");

        }
    }
}
