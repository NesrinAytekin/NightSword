using NightSword.Associate.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Associate.Vms
{
    public class ProductOfCategoryVM
    {
        public ProductOfCategoryVM()
        {
            Products= new List<ProductDto>();
            
        }
        public List<ProductDto> Products { get; set; }
        public CategoryDto CategoryDto { get; set; }
    }
}
