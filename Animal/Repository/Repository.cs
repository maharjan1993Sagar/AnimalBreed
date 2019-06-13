
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Animal.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private AnimalContext db;
        private DbSet<T> dbEntity;
        public Repository(AnimalContext Context)
        {
            db = Context;
            dbEntity = db.Set<T>();
        }
        public void Delete(int id)
        {
           T model= dbEntity.Find(id);
            dbEntity.Remove(model);
            Save();
        }

        public T GetById(int id)
        {
            return dbEntity.Find(id);
            
        }

        public IEnumerable<T> GetModel()
        {
            return dbEntity.ToList();

        }

        public void Insert(T Model)
        {
            dbEntity.Add(Model);
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
    }
}