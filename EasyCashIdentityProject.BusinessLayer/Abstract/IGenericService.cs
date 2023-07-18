using EasyCashIdentityProject.EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : BaseEntity
    {
        void TInsert(T t);
        void TUpdate(T t);
        void TDelete(T t);
        T TGetByID(int ID);
        IEnumerable<T> TGetAll();
        IEnumerable<T> TGetAll(Expression<Func<T, bool>> predicate);
    }
}
