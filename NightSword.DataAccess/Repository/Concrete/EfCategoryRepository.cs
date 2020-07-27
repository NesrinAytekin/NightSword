using NightSword.DataAccess.Context;
using NightSword.DataAccess.Repository.Abstract;
using NightSword.DataAccess.Repository.KernelRepository.Concrete;
using NightSword.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.DataAccess.Repository.Concrete
{
    public class EfCategoryRepository:EfKernelRepository<Category>,ICategoryRepository
    {
        public EfCategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
