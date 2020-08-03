using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NightSword.Associate.Dtos;
using NightSword.Business.Services.Abstract;

namespace NightSword.Web.Controllers
{
    public class PageController : Controller
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService)
        {
            this._pageService = pageService;
        }
        public IActionResult Page(string slug)
        {
            if (slug==null)
            {
                return View(_pageService.GetPages().Where(x => x.Slug == "home").FirstOrDefault());
            }

            PageDto page = _pageService.GetPages().Where(x => x.Slug == slug).FirstOrDefault();

            if (page==null)
            {
                return NotFound();
            }

            return View(page);

        }
    }
}