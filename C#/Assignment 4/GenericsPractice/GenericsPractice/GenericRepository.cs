using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Windows.Forms;

namespace GenericsPractice
{
     class GenericRepository<T> : IRepository<T> where T : class
     {
          private ApplicationContext context;
          internal DbSet<TEntity> dbSet;

          public GenericRepository(ApplicationContext context)
          {
               this.context = context;
               this.dbSet = context.Set<T>();
          }
          public void Add(T item)
          {
               dbSet.Add(item);
          }
          public void Remove(T item)
          {
               if (context.Entry(item).State == EntityState.Detached)
               {
                    dbSet.Attach(item);
               }
               dbSet.Remove(item);
          }
          public void Save()
          {
               context.SaveChanges();
          }
          public IEnumerable<T> GetAll()
          {
               return dbSet.ToList();
          }
          public T GetById(int id)
          {
               return dbSet.Find(id);
          }
     }
}
