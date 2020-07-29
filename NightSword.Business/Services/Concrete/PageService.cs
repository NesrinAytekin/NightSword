using AutoMapper;
using NightSword.Associate.Dtos;
using NightSword.Business.Services.Abstract;
using NightSword.Business.UnitofWork.Abstract;
using NightSword.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NightSword.Business.Services.Concrete
{
    public class PageService : IPageService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PageService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        public void Add(PageDto model)
        {
            

            model.Slug = model.Title.ToLower().Replace(" ", "-");
            model.Sorting = 100;

            var slug=_unitOfWork.Page.Find(x => x.Slug == model.Slug);

            if (slug ==null)
            {
               
                Page page = _mapper.Map<Page>(model);
                _unitOfWork.Page.Add(page);
                _unitOfWork.SaveChange();

            }

        }

        public void Delete(int id)
        {
            var page = _unitOfWork.Page.Find(x => x.Id == id);

            if (page!=null)
            {
                _unitOfWork.Page.Delete(page);
                _unitOfWork.SaveChange();
            }

        }

        public PageDto Get(int id)
        {
            Page page = _unitOfWork.Page.GetById(id);

            try
            {
                PageDto model = _mapper.Map<PageDto>(page);
                return model;
            }
            catch (Exception)
            {

                throw;
            }

        }

        IList<PageDto> IPageService.GetPages()
        {
            var pages = _unitOfWork.Page.GetAll().OrderByDescending(x => x.Title).ToList();

            var model = _mapper.Map<List<Page>, List<PageDto>>(pages);

            return model;
        }

        
        public void Update(PageDto model)
        {
            var ns = _unitOfWork.Page.Find(x => x.Id == model.Id);

            if (ns!=null)
            {
                model.Slug = model.Title.ToLower().Replace(" ", "-");
                model.Sorting = 10;

                var slug = _unitOfWork.Page.Find(x => x.Slug == model.Slug);

                if (slug == null)
                {

                    Page page = _mapper.Map<PageDto, Page>(model,ns);
                    _unitOfWork.Page.Update(page);
                    _unitOfWork.SaveChange();

                }
            }      

        }

        public void ReOrder(int[] id)
        {
            int count = 1;
            foreach (var pageid in id)
            {
                Page page = _unitOfWork.Page.GetById(pageid);
                page.Sorting = count;
                _unitOfWork.Page.Update(page);
                _unitOfWork.SaveChange();
                count++;
            }
            return;
        }
    }
}
