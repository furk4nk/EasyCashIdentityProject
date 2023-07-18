using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete;
using EasyCashIdentityProject.EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : BaseEntity
    {
        public void Delete(T t)
        {
            using EasyCashContext c = new();
            c.Set<T>().Remove(t);
            c.SaveChanges();

        }

        public IEnumerable<T> GetAll()
        {
            using EasyCashContext c = new();
            return c.Set<T>().AsNoTracking();

        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            using EasyCashContext c = new();
            return c.Set<T>().AsNoTracking();

        }

        public T GetByID(int ID)
        {
            using EasyCashContext c = new();
            return c.Set<T>().Find(ID);

        }

        public void Insert(T t)
        {
            using EasyCashContext c = new();
            c.Set<T>().Add(t);
            c.SaveChanges();

        }

        public void Update(T t)
        {
            using EasyCashContext c = new();
            c.Set<T>().Update(t);
            c.SaveChanges();
        }
    }
}
