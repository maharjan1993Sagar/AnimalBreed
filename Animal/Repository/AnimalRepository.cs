using Animal.Models;
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
    }
}
