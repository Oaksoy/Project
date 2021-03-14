using Microsoft.EntityFrameworkCore;
using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Project.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private DbContext context;

        public EfEntityRepositoryBase(DbContext dbContext) 
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext Boş Olamaz.");

            context = dbContext;
        }
        public void Add(TEntity entity)
        {
            
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
               
            
        }
        public void Delete(TEntity entity)
        {
            
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
             

        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            
                return context.Set<TEntity>().SingleOrDefault(filter);
            
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
           
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
           
        }

        public void Update(TEntity entity)
        {
            
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
              

        }

    }

}
