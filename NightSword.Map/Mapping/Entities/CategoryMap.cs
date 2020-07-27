using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NightSword.Entities.Entity;
using NightSword.Kernel.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Map.Mapping.Entities
{
    public class CategoryMap:KernelMap<Category>
    {
        //EntityTypeBuilder icin usinglere Microsoft.EntityFrameworkCore.Metadata.Builders eklenir.
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(25).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(256).IsRequired(false);
            builder.Property(x => x.Slug).IsRequired(false);
            builder.Property(x => x.Sorting).IsRequired(true);

            //builder.HasMany(x=>x.Products)
            //    .WithOne(x=>x.Category)
            //    .HasForeignKey(x=>x.CategoryId)
            //    .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);

        }
    }
}
