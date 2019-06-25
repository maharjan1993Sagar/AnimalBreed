using System;
using Animal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public interface IPregnencyNutritionRepository : IRepository<PregnancyBaseNutrition>
    {
        PregnancyBaseNutrition GetBySpecies(string species);
    }
}
