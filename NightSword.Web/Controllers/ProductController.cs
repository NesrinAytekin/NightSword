using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NightSword.Associate.Dtos;
using NightSword.Business.Services.Abstract;

namespace NightSword.Web.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
  

        public ProductController(IProductService productService)
        {
            this._productService = productService;
          
        }
        public IActionResult Index()
        {
            return View(_productService.GetProducts().OrderBy(x=>x.Name).ToList());
        }

        public IActionResult ProductsByCategory(int categoryId)
        {
            CategoryDto category =  _productService.GetCategories().Where(x => x.Id == categoryId).FirstOrDefault();

            if (category == null) return RedirectToAction("Index");

            ViewBag.CategoryName = category.Name;
            ViewBag.CategorySlug = categoryId;

            return View(_productService.GetProducts().Where(x => x.CategoryId == category.Id).ToList());
        }
    }
}