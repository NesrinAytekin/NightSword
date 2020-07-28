using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NightSword.Associate.Dtos;
using NightSword.Business.Services.Abstract;
using NightSword.Entities.Entity;

namespace NightSword.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageController : Controller
    {
        private readonly IPageService _pageService;
        public PageController(IPageService pageService)
        {
            this._pageService = pageService;
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PageDto pageDto)
        {

            if (ModelState.IsValid)
            {
                _pageService.Add(pageDto);
                TempData["Success"] = "Congurulation! Page Has Been Added";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Sorry!! Page Hasn't Been Added";
                return View(pageDto);
            }

        }
        public ActionResult<List<PageDto>> Index()
        {
            var pagelist = _pageService.GetPages();
            return View(pagelist);
        }
        public ActionResult Details(int id)
        {

            var page = _pageService.Get(id);
            if (page==null)
            {
                return NotFound();
            }
            return View(page);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PageDto page = _pageService.Get(id);
            return View(page);
        }

        [HttpPost]
        public ActionResult Edit(PageDto pageDto)
        {
             if (ModelState.IsValid)
            {
                
                _pageService.Update(pageDto);
                TempData["Success"] = "Congurulation! Page Has Been Changed";
                return RedirectToAction("Edit", new { id = pageDto.Id });
            }
            else
            {
                TempData["Error"] = "Sorry!! Page Hasn't Been Added";
                return View(pageDto);
            }
        }

        public ActionResult Delete(int id)
        {
            PageDto page = _pageService.Get(id);

            if (page==null)
            {
                TempData["Error"] = "The Page doesn't exist";
            }
            else
            {
                _pageService.Delete(id);
                TempData["Success"] = "The Page has been deleted";
                return RedirectToAction("Index");
                
            }
            return RedirectToAction("Index");
        }

    }
}