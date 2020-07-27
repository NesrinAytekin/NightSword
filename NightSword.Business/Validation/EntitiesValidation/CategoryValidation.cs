using FluentValidation;
using NightSword.Associate.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Business.Validation.EntitiesValidation
{
   public class CategoryValidation: AbstractValidator<CategoryDto>
    {
        //Bu Validationları hazırlamamızın en önemli sebebi tabikide performans ve guvenlik benm entity bazında hazırlamıs oldugum sorguları Db'ye gitmeden direk sorgulamayı yapmıs oluyorum aksi halde direk db'ye gider veri db'ye kaydedilme sartlarına bakar gereksiz yere db'ye bilgi tasımaının onune gecilirek performans kaybı onlendigi gibi tum sorgularıda tek bir yerde toplamıs olduk.
        public CategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("This fields cannot be empty..!").MaximumLength(140).WithMessage("You cannot use more than 140 character..!");
            
        }
    }
}
