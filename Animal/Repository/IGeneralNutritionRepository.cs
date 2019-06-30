using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public interface IGeneralNutritionRepository:IRepository<GeneralNutration>
    {
        GeneralNutration GetBySpecies(string species);

        GeneralNutration GetByWeight(string weight, string species);
    }
}
