﻿using NightSword.Associate.Dtos;
using NightSword.Associate.Vms;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Business.Services.Abstract
{
    public interface IProductService
    {

        public void Add(ProductDto model);
        public void Update(ProductDto model);
        public void Delete(int id);
        public ProductDto Get(int id);
        public IList<CategoryDto> GetCategories();

        public IList<ProductDto> GetProducts();

        //public IList<ProductOfCategoryVM> GetAll();
    }
}
