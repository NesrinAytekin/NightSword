using NightSword.DataAccess.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightSword.Business.UnitofWork.Abstract
{
    //Disposable Garbage Collector'a fırsat vermeden Ram'de temizlik islemini yapar.
    public interface IUnitOfWork:IDisposable
    {
        ICategoryRepository Category { get; }  
        IPageRepository Page { get; }
        IProductRepository Product { get; }
        void SaveChange();
      
    }
}
