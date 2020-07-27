using NightSword.Associate.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Business.Services.Abstract
{
   public interface ICategoryService
    {
        public void Add(CategoryDto model);
        public void Update(CategoryDto model);
        public void Delete(int id);
        public CategoryDto Get(int id);
        public IList<CategoryDto> GetCategories();

       // public IList<CategoryDto> GetCategorisesByDate(DateTime startedDate, DateTime endDate);
    }
}
