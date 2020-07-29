using NightSword.Kernel.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Entities.Entity
{
    public class Category:KernelEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int? Sorting { get; set; }
        public virtual ICollection<Product> Products { get; set; }


    }
}
