using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NightSword.Entities.Entity;
using NightSword.Kernel.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Map.Mapping.Entities
{
    public class PageMap:KernelMap<Page>
    {
        public override void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(25).IsRequired(true);
            builder.Property(x => x.Content).HasMaxLength(256).IsRequired(true);
            builder.Property(x => x.Slug).IsRequired(false);
            builder.Property(x => x.Sorting).IsRequired(true);

            base.Configure(builder);
        }
    }
}
