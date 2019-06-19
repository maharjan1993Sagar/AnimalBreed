<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Microsoft.EntityFrameworkCore;

namespace Animal.Repository
{

    public class FarmRepository : Repository<Farm>, IFarmRepository
    {
        private AnimalContext db;
        private DbSet<Farm> dbEntity;
     
        public FarmRepository(AnimalContext repositoryContext) : base(repositoryContext)
        {
            db = repositoryContext;
            dbEntity = db.Farms;
        }
      
        public Farm GetById(int id)
        {
            return dbEntity.Include(m=>m.OwnerKeepers).FirstOrDefault(m=>m.id==id);

        }
        
    }
  
=======
﻿using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public class FarmRepository:Repository<Farm>, IFarmRepository
    {
        public FarmRepository(AnimalContext Context):base(Context)
        {

        }
        public AnimalContext AnimalContext
        {
            get { return db as AnimalContext; }

        }

    }
>>>>>>> eab69796949eb7bb537bd59de1ba6f1246a33b7b
}
