using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NightSword.Associate.Dtos;
using NightSword.Business.Services.Abstract;

namespace NightSword.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryDto categoryDto)
        {

            if (ModelState.IsValid)
            {
                _categoryService.Add(categoryDto);
                TempData["Success"] = "Congurulation! Category Has Been Added";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Sorry!! Page Hasn't Been Added";
                return View(categoryDto);
            }

        }
        public ActionResult<List<CategoryDto>> Index()
        {
            var categorylist = _categoryService.GetCategories();
            return View(categorylist);
        }

        public ActionResult Edit(int id)
        {
            CategoryDto category = _categoryService.Get(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(categoryDto);
                TempData["Success"] = "Congurulation! Category Has Been Changed";
                return RedirectToAction("Index", new { id = categoryDto.Id });
            }
            else
            {
                TempData["Error"] = "Sorry!! Page Hasn't Been Added";
                return View(categoryDto);
            }
        }

        public ActionResult Delete(int id)
        {
            CategoryDto categoryDto = _categoryService.Get(id);

            if (categoryDto!=null)
            {
                _categoryService.Delete(id);
                TempData["Success"] = "The Page has been deleted";
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

    }
}