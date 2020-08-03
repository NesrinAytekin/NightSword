using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NightSword.Kernel.Repository.Abstract
{
    public interface IKernelRepository<T> //Jenerik Tip verdik.Bu class icerinde tüm entityler için ortak metodları yazıyoruz spesifik metodlar icin yazılacak metodlar o entity 'e ait Repository icerinde yazılır.
    {
        bool Any(Expression<Func<T, bool>> exp);

        void Add(T item);
        void Add(List<T> items);
        void Update(T item);
        void Delete(T item);
        void Delete(int id);
        void RemoveAll(Expression<Func<T, bool>> exp);

        T GetById(int id);
        T Find(Expression<Func<T, bool>> exp);

        ICollection<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        ICollection<T> FindByList(Expression<Func<T, bool>> exp);
    }
}
