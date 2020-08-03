using NightSword.Business.UnitofWork.Abstract;
using NightSword.DataAccess.Context;
using NightSword.DataAccess.Repository.Abstract;
using NightSword.DataAccess.Repository.Concrete;
using NightSword.Kernel.Entity.Concrete;
using System;
using System.Linq;
using System.Security.Principal;

namespace NightSword.Business.UnitofWork.Concrete
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public EfUnitOfWork(ApplicationDbContext db)
        {
            this._db = db ?? throw new ArgumentNullException("DataBase can't be null");//(??) degilse anlamındadır.Db Bos ise bu mesajı ilet diyoruz.
        }

        //Her bir entity icin bu islem tamamlanır.

        private ICategoryRepository _categoryRepository;        
        
        public ICategoryRepository Category
        {
            get { return _categoryRepository ?? (_categoryRepository = new EfCategoryRepository(_db)); }
        }


        private IPageRepository _pageRepository;
        public IPageRepository Page
        {
            get { return _pageRepository ?? (_pageRepository = new EfPageRepository(_db)); }
        }

        private IProductRepository _productRepository;
        public IProductRepository Product
        {
            get { return _productRepository ?? (_productRepository = new EfProductRepository(_db)); }
        }

        //Not:Disposable Garbage Collector'a fırsat vermeden Ram'de temizlik islemini yapar.

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)//Virtual olarak isaretledikki override edebilelim.
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true); //Yukarıda virtuall olarak hazırladigimiz metodu burada override edip true olarak belirtiyoruz.
            GC.SuppressFinalize(this);
        }

        public void SaveChange()
        {
            var modifiedentities = _db.ChangeTracker.Entries().Where(x => x.State == Microsoft.EntityFrameworkCore.EntityState.Modified || x.State == Microsoft.EntityFrameworkCore.EntityState.Added).ToList();

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            string ipAdress = "127.0.0.1";
            DateTime date = DateTime.Now;


            foreach (var item in modifiedentities)
            {
                KernelEntity entity = item.Entity as KernelEntity;

                if (item != null)
                {
                    switch (item.State)
                    {

                        case Microsoft.EntityFrameworkCore.EntityState.Modified:
                            entity.ModifiedComputerName = computerName;
                            entity.ModifiedBy = ipAdress;
                            entity.CreatedBy = identity;
                            entity.ModifiedDate = date;
                            entity.Status = Kernel.Enums.Status.Modified;
                            break;
                        case Microsoft.EntityFrameworkCore.EntityState.Added:
                            entity.CreatedComputerName = computerName;
                            entity.CreatedIp = ipAdress;
                            entity.CreatedBy = computerName;
                            entity.Status = Kernel.Enums.Status.Active;
                            break;
                        default:
                            break;
                    }
                }
            }

            try
            {
                using (var transaction = _db.Database.BeginTransaction())
                {


                    try
                    {
                        _db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

   
    }
}
