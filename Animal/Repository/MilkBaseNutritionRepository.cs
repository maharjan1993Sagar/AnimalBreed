using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;

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
    }
}
