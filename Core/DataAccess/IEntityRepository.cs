using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // Generic Constraint
    // class : Referans tipi olabilir demek.
    // IEntity olmalı ya da IEntity implemente eden bir nesne olmalı.
    // new() : new'lenebilir olmalı.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {

        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
