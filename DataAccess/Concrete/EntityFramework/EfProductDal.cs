using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // IDisposable patten implementation of c#
            using (NortwindContext context=new NortwindContext())
            {
                // Referansı yakala
                var addedEntity = context.Entry(entity);
                // Yakalanan alana ekleme yap
                addedEntity.State = EntityState.Added;
                // Değişiklikleri kaydet
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            // IDisposable patten implementation of c#
            using (NortwindContext context = new NortwindContext())
            {
                // Referansı yakala
                var deletedEntity = context.Entry(entity);
                // Yakalanan alana ekleme yap
                deletedEntity.State = EntityState.Deleted;
                // Değişiklikleri kaydet
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NortwindContext context = new NortwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NortwindContext context = new NortwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();

            }
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            // IDisposable patten implementation of c#
            using (NortwindContext context = new NortwindContext())
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
