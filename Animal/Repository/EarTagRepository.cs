using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public class EarTagRepository:Repository<EarTag>,IEarTagRepository
    {
        public EarTagRepository(AnimalContext Context)
            : base(Context)
        {
        }
        public AnimalContext AnimalContext
        {
            get { return db as AnimalContext; }

        }

        public EarTag GetByTag(string tag)
        {
            if (db.EarTags.Any(m => m.earTagNoStr == tag))
            {
                return db.EarTags.FirstOrDefault(m => m.earTagNoStr == tag);
            }
            else {
                return null;
            }

        }
    }
}
