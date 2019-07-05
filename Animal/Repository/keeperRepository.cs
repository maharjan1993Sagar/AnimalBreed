
using Animal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public class keeperRepository : Repository<keeper>, IKeeperRepository
    {
        public keeperRepository(AnimalContext Context)
            : base(Context)
        {
        }

        public AnimalContext AnimalContext
        {
            get { return db as AnimalContext; }

        }
        public IEnumerable<keeper> GetModel()
        {
            return db.Keeper.Include(M => M.farm).ToList();
        }

        public keeper GetById(int id)
        {
            return db.Keeper.Include(m => m.farm).Include(m => m.farm).FirstOrDefault(m => m.id == id);

        }

    }
}
