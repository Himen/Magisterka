using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.EF.Repositories
{
    public class Repository<T> : IRepository<T> where T: class
    {
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public Repository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbcontext nie został zdefiniowany");
            }
            else
            {
                DbContext = dbContext;
                DbSet = dbContext.Set<T>();
            }

        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> pred)
        {
            return DbSet.Where(pred);
        }

        public virtual T GetById(long id)
        {
            return DbSet.Find(id);
        }

        public virtual T GetByGuid(Guid guid)
        {
            return DbSet.Find(guid);
        }

        public virtual void Remove(T entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
        }
        public virtual void RemoveById(long id)
        {
            T entity = DbSet.Find(id);
            Remove(entity);
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
