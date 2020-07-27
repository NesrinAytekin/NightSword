using NightSword.Entities.Entity;
using NightSword.Kernel.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.DataAccess.Repository.Abstract
{
    //Category'ilere ait ozel islemleri burada ihtiyac oldukca burada obekleyecegiz.
    public interface ICategoryRepository : IKernelRepository<Category>
    {

    }
}
