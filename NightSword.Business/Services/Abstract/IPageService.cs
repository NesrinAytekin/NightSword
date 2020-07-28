using NightSword.Associate.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Business.Services.Abstract
{
    public interface IPageService
    {

        public void Add(PageDto model);
        public void Update(PageDto model);
        public void Delete(int id);
        public PageDto Get(int id);
        public void ReOrder(int[] id);
        public IList<PageDto> GetPages();
    }
}
