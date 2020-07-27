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
           
            _pageService.Add(pageDto);
            return View();
        }
        public ActionResult<List<PageDto>> Index()
        {
            var pagelist = _pageService.GetPages();
            return View(pagelist);
        }

    }
}