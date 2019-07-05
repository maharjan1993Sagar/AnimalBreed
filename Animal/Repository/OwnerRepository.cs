using Animal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public class OwnerRepository:  Repository<OwnerKeeper>, IOwnerRepository
    {

        public OwnerRepository(AnimalContext Context):base(Context)
        {

        }
        public AnimalContext AnimalContext
        {
            get { return db as AnimalContext; }

        }

        public IEnumerable<OwnerKeeper> GetModel()
        {
            return db.OwnerKeeper.Include(M => M.farm).ToList();
        }

        public OwnerKeeper GetById(int id)
        {
            return db.OwnerKeeper.Include(m => m.farm).Include(m => m.farm).FirstOrDefault(m => m.id == id);

        }

    }
}
