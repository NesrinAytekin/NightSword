using Microsoft.EntityFrameworkCore;
using NightSword.DataAccess.Context;
using NightSword.Kernel.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NightSword.DataAccess.Repository.KernelRepository.Concrete
{
    public class EfKernelRepository<T> : IKernelRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;

        protected DbSet<T> table;
        public EfKernelRepository(ApplicationDbContext context)
        {
            this._context = context;
            this.table = _context.Set<T>();
        }
        public void Add(T item)
        {
            table.Add(item);
        }

        public void Add(List<T> items)
        {
            table.AddRange(items);
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return table.Any(exp);
        }

        public void Delete(T item)
        {
            table.Remove(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Find(Expression<Func<T, bool>> exp)
        {
            return table.Where(exp).FirstOrDefault();
        }

        public ICollection<T> FindByList(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            table.Update(item);
        }
    }
}
