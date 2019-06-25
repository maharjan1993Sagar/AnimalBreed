using Animal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public class PregnencyNutritionRepository : Repository<PregnancyBaseNutrition>, IPregnencyNutritionRepository
    {
        public PregnencyNutritionRepository(AnimalContext Context)
            : base(Context)
        {
        }
        public AnimalContext AnimalContext
        {
            get { return db as AnimalContext; }

        }
        public PregnancyBaseNutrition GetBySpecies(string species)
        {
            return db.Set<PregnancyBaseNutrition>().FirstOrDefault(m => m.weight == species);
        }

        public IEnumerable<PregnancyBaseNutrition> GetModel()
        {
            return db.PregnancyBaseNutritions.Include(M => M.Species).ToList();
        }
    }
}
