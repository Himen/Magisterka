using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.Core.BasicContract
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        void Attach(ref TEntity entity);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> pred);
        TEntity GetById(TKey id);
        void Remove(TEntity entity);
        void RemoveById(TKey id);
        void RemoveFinaly(TEntity entity);
        void RemoveFinalyById(TKey id);
        void Add(TEntity entity);
        void Update(TEntity entity);
    }
}
