using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetModel();
        T GetById(int id);
        void Insert(T Model);
        void Delete(int id);
        void Update(T Model);
        void Save();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
       

    }
}
