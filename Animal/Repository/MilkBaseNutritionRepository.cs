using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
using Microsoft.EntityFrameworkCore;

namespace Animal.Repository
{
    public class MilkBaseNutritionRepository : Repository<MIlkBaseNutrition>,IMilkBaseNutritionRepository
    {
        public MilkBaseNutritionRepository(AnimalContext Context)
           : base(Context)
        {
        }
        public AnimalContext AnimalContext
        {
            get { return db as AnimalContext; }

        }

        public IEnumerable<MIlkBaseNutrition> GetModel()
        {
            return db.MilkBaseNutritions.Include(M => M.Species).ToList();
        }

        public MIlkBaseNutrition GetByFat(string fat,int species)
        {
            return db.Set<MIlkBaseNutrition>().FirstOrDefault(m => m.fatPercentage == fat  && m.SpeciesId==species);
        }
    }
}
