using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // Core katmanı evrensel bir katman olacak. Sadece northwind için olmayacak
    // Core katmanı diğer katmanları referans almaz.
    // Generic Constraint
    //class: referans tip
    //IEntity: IEntity  olabilir veya implemente eden bir nesne olabilir.
    //new(): new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new() // Class:Referans tip, olmak zorunda olur generic yapı.int vs olmaz
    {
        // Generic repository design patern
        List<T> GetAll(Expression<Func<T,bool>> filter=null); // Örnek category idsi 2 olanları getir, şu fiyatta olanları getir, e-ticaret sitesinde filtreleme 
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
