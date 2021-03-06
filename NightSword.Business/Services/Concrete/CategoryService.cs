﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
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
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
       
        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;           
        }
        public void Add(CategoryDto model)
        {
            Category categoryobj = _mapper.Map<Category>(model);
            _unitOfWork.Category.Add(categoryobj);
            _unitOfWork.SaveChange();
        }

        public void Delete(int id)
        {
            Category obj = _unitOfWork.Category.GetById(id);

            if (obj!=null)
            {
                _unitOfWork.Category.Delete(obj);
                _unitOfWork.SaveChange();
            }
          
        }

        public CategoryDto Get(int id)
        {
            Category obj = _unitOfWork.Category.GetById(id);

            try
            {
                CategoryDto model = _mapper.Map<CategoryDto>(obj);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<CategoryDto> GetCategories()
        {
            var categories = _unitOfWork.Category.GetAll().OrderByDescending(x => x.CreateDate).ToList();
            var model = _mapper.Map<List<Category>, List<CategoryDto>>(categories);
            return model;

        }

        public void Update(CategoryDto model)
        {


            var obj = _unitOfWork.Category.Find(x => x.Id == model.Id);

            if (obj!=null)
            {
                Category category = _mapper.Map<CategoryDto, Category>(model, obj);
                _unitOfWork.Category.Update(category);
                _unitOfWork.SaveChange();
            }
        }
    }
}
