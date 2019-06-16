using Animal.Models;
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
    }
}
