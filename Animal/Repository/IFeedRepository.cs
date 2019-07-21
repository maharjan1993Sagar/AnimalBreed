using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public interface IFeedRepository:IRepository<FeedFooder>
    {
        IEnumerable<FeedFooder> GetByCategory(string category);
        IEnumerable<FeedFooder> GetCategories();

    }
}
