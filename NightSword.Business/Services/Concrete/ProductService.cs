using AutoMapper;
using NightSword.Associate.Dtos;
using NightSword.Business.Services.Abstract;
using NightSword.Business.UnitofWork.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Business.Services.Concrete
{
    public class ProductService : IProductService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public void Add(ProductDto model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProductDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ProductDto> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductDto model)
        {
            throw new NotImplementedException();
        }
    }
}
