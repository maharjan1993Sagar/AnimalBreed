using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Models;

namespace Animal.Repository
{
    public interface IVaccinationRepository :IRepository<Vaccination>,IRepository<VaccinationSubType>,IRepository<VaccinationAnimal>
    {
        IRepository<Vaccination> Vaccination { get; }
        IRepository<VaccinationType> VaccinationType { get; }
       IRepository<VaccinationSubType> VaccinationSubType { get; }
        IRepository<VaccinationAnimal> VaccinationAnimal { get; }

        void Save();
    }
}
