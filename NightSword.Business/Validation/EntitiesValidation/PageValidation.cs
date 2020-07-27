using FluentValidation;
using NightSword.Associate.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Business.Validation.EntitiesValidation
{
    public class PageValidation: AbstractValidator<PageDto>
    {
        //Bu Validationları hazırlamamızın en önemli sebebi tabikide performans ve guvenlik benm entity bazında hazırlamıs oldugum sorguları Db'ye gitmeden direk sorgulamayı yapmıs oluyorum aksi halde direk db'ye gider veri db'ye kaydedilme sartlarına bakar gereksiz yere db'ye bilgi tasımanın onune gecilirek performans kaybı onlendigi gibi tum sorgularıda tek bir yerde toplamıs olduk.

        public PageValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("This fields cannot be empty..!").MinimumLength(2).WithMessage("Minumum Length is 2");
            RuleFor(x => x.Content).NotEmpty().WithMessage("This fields cannot be empty..!").MinimumLength(4).WithMessage("Minumum Length is 4");
        }
    }
}
