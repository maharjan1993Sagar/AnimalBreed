using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        protected AnimalContext _repoContext;
        public IAnimalRepository _animal;
        public IBreedRepository _breed;
        public IOwnerRepository _owner;
        public IFarmRepository _farm;
        public IRepository<FeedFooder> _feed;

        public UnitOfWork(AnimalContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IAnimalRepository AnimalRegistration
        {
            get
            {
                if (_animal == null)
                {
                    _animal = new AnimalRepository(_repoContext);
                }

                return _animal;
            }
        }
        public IRepository<FeedFooder> FeedFoooder
        {
            get
            {
                if (_feed == null)
                {
                    _feed = new Repository<FeedFooder>(_repoContext);
                }

                return _feed;
            }
        }

        public IBreedRepository Breed
        {
            get
            {
                if (_breed == null)
                {
                    _breed = new BreedRepository(_repoContext);
                }

                return _breed;
            }
        }

        public IOwnerRepository OwnerKeeper
        {
            get
            {
                if (_owner == null)
                {
                    _owner = new OwnerRepository(_repoContext);
                }

                return _owner;
            }
        }
        public new IFarmRepository Farm
        {
            get
            {
                if (_farm == null)
                {
                    _farm = new FarmRepository(_repoContext);
                }

                return _farm;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }

    }
}
