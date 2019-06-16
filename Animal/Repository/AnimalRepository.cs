using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public class AnimalRepository: Repository<AnimalRegistration>, IAnimalRepository
    {
        public AnimalRepository(AnimalContext Context)
            : base(Context)
        {
        }

       
    }
}
