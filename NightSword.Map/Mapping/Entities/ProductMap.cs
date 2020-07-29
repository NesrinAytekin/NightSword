using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NightSword.Entities.Entity;
using NightSword.Kernel.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Map.Mapping.Entities
{
    public class ProductMap:KernelMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Price).IsRequired(true);
            builder.Property(x => x.Image).IsRequired(false);
            builder.Property(x => x.Slug).IsRequired(false);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            base.Configure(builder);
        }
    }
}
