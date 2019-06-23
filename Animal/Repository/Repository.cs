
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace Animal.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected AnimalContext db;
       // private DbSet<T> dbEntity;
        public Repository(AnimalContext Context)
        {
            db = Context;
            //dbEntity = db.Set<T>();
        }
        public void Delete(int id)
        {
           T model= db.Set<T>().Find(id);
            db.Set<T>().Remove(model);
            Save();
        }

        

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
            
        }

        public IEnumerable<T> GetModel()
        {
            return db.Set<T>().ToList();

        }

        public void Insert(T Model)
        {
            db.Set<T>().Add(Model);
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T Model)
        {
            db.Entry(Model).State = EntityState.Modified;
            Save();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.db.Set<T>().Where(expression).AsNoTracking();
        }

    }
}