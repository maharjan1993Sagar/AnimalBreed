using System;
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
  
}
