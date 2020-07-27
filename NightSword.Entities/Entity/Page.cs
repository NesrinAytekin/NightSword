using NightSword.Kernel.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Entities.Entity
{
   public class Page:KernelEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }      
        public string Content { get; set; }
        public int Sorting { get; set; }
    }
}
