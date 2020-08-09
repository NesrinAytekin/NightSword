using Microsoft.AspNetCore.Mvc;
using NightSword.Associate.Dtos;
using NightSword.Business.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightSword.Web.Infrastructure.Components
{
    public class CategoryViewComponent:ViewComponent
    {

        private readonly ICategoryService _categoryService;

        public CategoryViewComponent(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var categorylist = GetPageAsync();
            return View(categorylist);
        }

        private List<CategoryDto> GetPageAsync()
        {
            return _categoryService.GetCategories().OrderBy(x => x.Sorting).ToList();
        }
    }
}
