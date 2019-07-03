using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public interface IUnitOfWork :IDisposable
    {
         IAnimalRepository AnimalRegistration { get; }
         IBreedRepository Breed { get; }
         IOwnerRepository OwnerKeeper { get; }
         IFarmReository Farm { get; }
         IFeedRepository FeedFooder { get; }
        IMilkBaseNutritionRepository MilkBase { get; }
        IMilkRecordRepository MilkRecord { get; }
        IPregnencyNutritionRepository PregnancyBaseNutrition { get; }
        ISpeciesRepository Species { get; }
        ILabRepository labs { get; }
        IKeeperRepository keepers{ get; }
        IGeneralNutritionRepository GeneralNutrition { get; }

        IEarTagRepository EarTag { get; }

        void Save();
    }
}
