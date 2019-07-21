using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;
namespace Animal.Repository
{
  public interface IMilkBaseNutritionRepository:IRepository<MIlkBaseNutrition>
    {
        MIlkBaseNutrition GetByFat(string fat,int species);
    }
}
