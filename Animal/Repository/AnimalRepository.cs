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
        public IEnumerable<AnimalRegistration> GetModel()
        {
            return db.animalRegistration.Include(M => M.Species).Include(m => m.Breed).Include(m=>m.Farm).Include(m=>m.AnimalOwners).ToList();

        }

        public AnimalRegistration GetById(int id)
        {
            return db.animalRegistration.Include(m => m.Species).Include(m => m.Breed).FirstOrDefault(m => m.id == id);

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


            db.animalRegistration.Add(animal);

            db.SaveChanges();
            keeper keeper = db.keeper.FirstOrDefault(m => m.id == animal.keeperId);
            animal.keeper = keeper;
            animal = db.animalRegistration.LastOrDefault();
            if (db.OwnerKeeper.Any(m => m.id == animal.ownerId))
            {
                AnimalOwner animalowner = new AnimalOwner();
                animalowner.Owner = db.OwnerKeeper.Find(Convert.ToInt32(animal.ownerId));
                animalowner.OwnerId = Convert.ToInt32(animal.ownerId);
                animalowner.AnimalId = animal.id;
                animalowner.AnimalRegistration = animal;

                db.AnimalOwners.Add(animalowner);
                db.SaveChanges();
            }

        }

        public void Update(AnimalRegistration animal)
        {
            db.Entry(animal).State = EntityState.Modified;
            db.SaveChanges();

            AnimalOwner animalOwner = db.AnimalOwners.FirstOrDefault(m => m.AnimalId == animal.id && m.OwnerId == animal.ownerId);
            if (animalOwner != null)
            {
                db.AnimalOwners.Remove(animalOwner);
                db.SaveChanges();
            }


            if (animal.ownerId!=null)
            {
                    AnimalOwner aniOwner = new AnimalOwner();
                    aniOwner.Owner = db.OwnerKeeper.Find(Convert.ToInt32(animal.ownerId));
                    aniOwner.OwnerId = Convert.ToInt32(animal.ownerId);
                    aniOwner.AnimalId = animal.id;
                    aniOwner.AnimalRegistration = animal;
                    db.AnimalOwners.Add(aniOwner);
            }
            
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var animal = db.animalRegistration.Find(id);
            AnimalOwner animalOwner = db.AnimalOwners.FirstOrDefault(m => m.AnimalId == animal.id && m.OwnerId == animal.ownerId);
            if (animalOwner != null)
            {
                db.AnimalOwners.Remove(animalOwner);
                db.SaveChanges();
            }
            db.animalRegistration.Remove(animal);
            db.SaveChanges();
        }
    }
}
