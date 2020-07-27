using NightSword.DataAccess.Context;
using NightSword.DataAccess.Repository.Abstract;
using NightSword.DataAccess.Repository.KernelRepository.Concrete;
using NightSword.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.DataAccess.Repository.Concrete
{
    public class EfPageRepository : EfKernelRepository<Page>, IPageRepository
    {
        public EfPageRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
    }
}
