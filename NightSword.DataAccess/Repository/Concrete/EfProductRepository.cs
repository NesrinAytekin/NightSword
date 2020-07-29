using NightSword.DataAccess.Context;
using NightSword.DataAccess.Repository.Abstract;
using NightSword.DataAccess.Repository.KernelRepository.Concrete;
using NightSword.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.DataAccess.Repository.Concrete
{
    public class EfProductRepository : EfKernelRepository<Product>, IProductRepository
    {
        public EfProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
