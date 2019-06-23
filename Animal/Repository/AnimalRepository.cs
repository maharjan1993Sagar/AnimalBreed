using Animal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public class AnimalRepository : Repository<AnimalRegistration>, IAnimalRepository
    {
        public AnimalRepository(AnimalContext Context)
            : base(Context)
        {
        }

        public AnimalContext AnimalContext
        {
            get { return db as AnimalContext; }

        }
        public IEnumerable<AnimalRegistration> GetModel() {
            return db.animalRegistration.Include(M => M.Species).ToList();
        }
    }
}
