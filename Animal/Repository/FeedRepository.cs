using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public class FeedRepository:Repository<FeedFooder>, IFeedRepository
    {
        public FeedRepository(AnimalContext Context):base(Context)
        {

        }
        public AnimalContext AnimalContext
        {
            get { return db as AnimalContext; }

        }

        public IEnumerable<FeedFooder> GetByCategory(string category)
        {
            return db.FeedFooder.Where(m => m.category == category).ToList();
        }


        public IEnumerable<FeedFooder> GetCategories()
        {
            return db.FeedFooder.GroupBy(m => m.category)
                  .Select(grp => grp.First())
                  .ToList();
        }

    }
}
