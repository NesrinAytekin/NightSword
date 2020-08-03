using Microsoft.AspNetCore.Mvc;
using NightSword.Associate.Dtos;
using NightSword.Business.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightSword.Web.Infrastructure.Components
{
    public class MainMenuViewComponent : ViewComponent
    {
        private readonly IPageService _pageService;

        public MainMenuViewComponent(IPageService pageService)
        {
            this._pageService = pageService;
        }

        public IViewComponentResult Invoke()
        {
            var pagelist = GetPageAsync();
            return View(pagelist);
        }

        private List<PageDto> GetPageAsync()
        {
            return _pageService.GetPages().OrderBy(x => x.Sorting).ToList();
        }
    }
}
