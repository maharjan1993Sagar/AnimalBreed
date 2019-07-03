using Animal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public class BreedRepository : Repository<Breed>, IBreedRepository
    {
        public BreedRepository(AnimalContext Context)
            : base(Context)
        {
        }
        public AnimalContext AnimalContext
        {
            get { return db as AnimalContext; }

        }

        public IEnumerable<Breed> GetModel()
        {
            return db.Breeds.Include(M => M.species).ToList();
        }
        public IEnumerable<Breed> GetBySpecies(int species)
        {
            return db.Breeds.Include(M => M.species).Where(m=>m.speciesId==species).ToList();
        }
    }
}
