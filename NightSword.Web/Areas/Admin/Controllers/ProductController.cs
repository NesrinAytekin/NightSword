using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NightSword.Associate.Dtos;
using NightSword.Business.Services.Abstract;

namespace NightSword.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_productService.GetCategories(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductDto productDto)
        {
           

            if (ModelState.IsValid)
            {
                _productService.Add(productDto);
                TempData["Success"] = "Congurulation! Product Has Been Added";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Sorry!! Page Hasn't Been Added";
                return View(productDto);
            }

        }
        public ActionResult<List<ProductDto>> Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }

        public ActionResult Details(int id)
        {

            var product = _productService.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(_productService.GetCategories(), "Id", "Name");
            ProductDto product = _productService.Get(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductDto productDto)
        {
           

            if (ModelState.IsValid)
            {
               
                _productService.Update(productDto);
                TempData["Success"] = "Congurulation! Product Has Been Changed";
                return RedirectToAction("Index", new { id = productDto.Id });
            }
            else
            {
                TempData["Error"] = "Sorry!! Product Hasn't Been Added";
                return View(productDto);
            }
        }

        public ActionResult Delete(int id)
        {
            ProductDto product = _productService.Get(id);

            if (product == null)
            {
                TempData["Error"] = "The Page doesn't exist";
            }
            else
            {
                _productService.Delete(id);
                TempData["Success"] = "The Product has been deleted";
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }
}