using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> 
        where TEntity : class, IEntity, new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            // IDisposable patten implementation of c#
            using (TContext context = new TContext())
            {
                // Referansı yakala
                var addedEntity = context.Entry(entity);
                // Yakalanan alana ekleme yap
                addedEntity.State = EntityState.Added;
                // Değişiklikleri kaydet
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            // IDisposable patten implementation of c#
            using (TContext context = new TContext())
            {
                // Referansı yakala
                var deletedEntity = context.Entry(entity);
                // Yakalanan alana ekleme yap
                deletedEntity.State = EntityState.Deleted;
                // Değişiklikleri kaydet
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        public List<TEntity> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            // IDisposable patten implementation of c#
            using (TContext context = new TContext())
            {
                // Referansı yakala
                var updatedEntity = context.Entry(entity);
                // Yakalanan alana ekleme yap
                updatedEntity.State = EntityState.Modified;
                // Değişiklikleri kaydet
                context.SaveChanges();
            }
        }
    }
}
