using Animal.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public IEnumerable<AnimalRegistration> GetByGender(string gender)
        {
            return db.animalRegistration.Include(m => m.Species).Include(m => m.Breed).Where(m => m.gender == gender).ToList();
        }

        public AnimalRegistration GetByEartag(string eartag)
        {
            return db.animalRegistration.FirstOrDefault(m => m.earTagNo == eartag);

        }

        public void Insert(AnimalRegistration animal)
        {
            AnimalOwner animalowner = new AnimalOwner();
            animalowner.Owner = db.OwnerKeeper.Find(Convert.ToInt32(animal.ownerId));
            animalowner.OwnerId = Convert.ToInt32(animal.ownerId);
            animal.AnimalOwners.Add(animalowner);

            db.animalRegistration.Add(animal);

            db.SaveChanges();
            animal = db.animalRegistration.LastOrDefault();

            

        }
    }
}
