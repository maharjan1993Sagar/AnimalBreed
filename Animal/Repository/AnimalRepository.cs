using Animal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            return db.animalRegistration.Include(M => M.Species).Include(m=>m.Breed).ToList();
            
        }

        public AnimalRegistration GetById(int id)
        {
            return db.animalRegistration.Include(m => m.Species).Include(m=>m.Breed).FirstOrDefault(m=>m.id==id);

        }
    }
}
