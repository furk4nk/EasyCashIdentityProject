using EasyCashIdentityProject.EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : BaseEntity
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        T GetByID(int ID);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T,bool>> predicate);
    }
}
