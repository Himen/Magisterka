using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.EF.Repositories
{
    public interface IRepository<T> where T: class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> pred);
        T GetById(long id);
        T GetByGuid(Guid guid);
        void Remove(T entity);
        void RemoveById(long id);
        void Add(T entity);
        void Update(T entity);
    }
}
