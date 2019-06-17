using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public class IUnitOfWork
    {
        public IAnimalRepository AnimalRegistration { get; }
        public IBreedRepository Breed { get; }
        public IOwnerRepository OwnerKeeper { get; }
        public IFarmRepository Farm { get; }
        public IFeedRepository FeedFooder { get; }
        public void Save() { }
    }
}
