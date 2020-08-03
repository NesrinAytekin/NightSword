using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using NightSword.Associate.Dtos;
using NightSword.Associate.Vms;
using NightSword.Business.Services.Abstract;
using NightSword.Business.UnitofWork.Abstract;
using NightSword.Entities.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NightSword.Business.Services.Concrete
{
    public class ProductService : IProductService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._webHostEnvironment = webHostEnvironment;
        }

        public void Add(ProductDto model)
        {
            if (model.ImageUpload != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                string fileName = Path.GetFileName(model.ImageUpload.FileName);

                using (FileStream stream = new FileStream(Path.Combine(uploadDir, fileName), FileMode.Create))
                {
                    model.ImageUpload.CopyTo(stream);
                    model.Image = fileName;
                }
            }



            Product product = _mapper.Map<Product>(model);
            _unitOfWork.Product.Add(product);
            _unitOfWork.SaveChange();
        }

        public void Delete(int id)
        {
            Product product = _unitOfWork.Product.Find(x => x.Id == id);

            if (product == null)
            {
                return;
            }
            else
            {
                if (!string.Equals(product.ImageUpload, "noimage.png"))
                {
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
                    string oldImagePath = Path.Combine(uploadDir, product.Image);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                _unitOfWork.Product.Delete(product);
                _unitOfWork.SaveChange();
            }
        }

        public ProductDto Get(int id)
        {
            Product product = _unitOfWork.Product.GetById(id);

            try
            {
                ProductDto model = _mapper.Map<ProductDto>(product);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public IList<ProductOfCategoryVM> GetAll()
        //{
        //    var products = _unitOfWork.Product.GetAll.OrderByDescending(x => x.Price).ToList();
        //    var model = _mapper.Map<List<Product>, List<ProductOfCategoryVM>>(products);
        //    return model;
        //}

        public IList<CategoryDto> GetCategories()
        {
            //var products = _unitOfWork.Product.FindByList(x=>x.CategoryId==categoryId).OrderBy(x=>x.Category.Name).ToList();

            //var categories=_unitOfWork.Category.GetAll().OrderBy(x => x.Name).ToList();

            IList<CategoryDto> model = null;

            var categories = from u in _unitOfWork.Category.GetAll() select u;

            categories = categories.OrderBy(x => x.Name).ToList();


            model = _mapper.Map<List<CategoryDto>>(categories);
            return model;
        }

        public IList<ProductDto> GetProducts()
        {
            var products = _unitOfWork.Product.GetAll(include: x => x
               .Include(z => z.Category)).OrderByDescending(x => x.Price).ToList();

            var model = _mapper.Map<List<Product>, List<ProductDto>>(products);

            return model;
        }

        public void Update(ProductDto model)
        {
            var obj = _unitOfWork.Product.Find(x => x.Id == model.Id);

            if (model.ImageUpload != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");

                if (!Directory.Exists(uploadDir)) 
                {
                    
                    Directory.CreateDirectory(uploadDir);
                }

                string fileName = Path.GetFileName(model.ImageUpload.FileName);

                using (FileStream stream = new FileStream(Path.Combine(uploadDir, fileName), FileMode.Create))
                {
                    model.ImageUpload.CopyTo(stream);
                    model.Image = fileName;
                }

                Product product = _mapper.Map<ProductDto, Product>(model, obj);
                _unitOfWork.Product.Update(product);
                _unitOfWork.SaveChange();
            }
        }
    }
}





       