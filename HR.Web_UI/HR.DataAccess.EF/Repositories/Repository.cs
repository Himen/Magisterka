using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HR.Core.BasicContract;
using System.Reflection;

namespace HR.DataAccess.EF.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected DbContext DbContext { get; set; }
        protected DbSet<TEntity> DbSet { get; set; }

        public Repository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbcontext nie został zdefiniowany");
            }
            else
            {
                DbContext = dbContext;
                DbSet = dbContext.Set<TEntity>();
            }

        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> pred)
        {
            return DbSet.Where(pred);
        }

        public virtual TEntity GetById(TKey id)
        {
            return DbSet.Find(id);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity " + typeof(TEntity).Name);

            // trzeba pobrac nazwe atrybutu DataState i modified date
            //http://stackoverflow.com/questions/9113020/get-attribute-info-with-generics
            //http://stackoverflow.com/questions/1089123/setting-a-property-by-reflection-with-a-string-valuev

            PropertyInfo propertyInfo = entity.GetType().GetProperty("DataState");
            propertyInfo.SetValue(entity, Convert.ChangeType(0, propertyInfo.PropertyType), null);

            propertyInfo = entity.GetType().GetProperty("EditDate");
            propertyInfo.SetValue(entity, Convert.ChangeType(DateTime.Now, propertyInfo.PropertyType), null);

            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void RemoveById(TKey id)
        {
            throw new NotImplementedException();
        }


        public virtual void RemoveFinaly(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity " + typeof(TEntity).Name);

            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
        }
        public virtual void RemoveFinalyById(TKey id)
        {
            TEntity entity = DbSet.Find(id);

            if (entity == null)
                throw new ArgumentNullException("Entity " + typeof(TEntity).Name);

            RemoveFinaly(entity);
        }

        public virtual void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity " + typeof(TEntity).Name);

            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity " + typeof(TEntity).Name);

            PropertyInfo propertyInfo = entity.GetType().GetProperty("EditDate");
            propertyInfo.SetValue(entity, Convert.ChangeType(DateTime.Now, propertyInfo.PropertyType), null);

            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

    }
}
