using Animal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public class AnimalContext: DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options)
        : base(options)
        {
        }

        public DbSet<feedFooder> feedFooder{ get; set; }
        public DbSet<Vaccination> vaccinations { get; set; }
        public DbSet<VaccinationType> vaccinationTypes { get; set; }

        public DbSet<VaccinationSubType> vaccinationSubType { get; set; }
        public DbSet<Diseases> diseases{ get; set; }
        public DbSet<VaccinationAnimal> vaccinationAnimals{ get; set; }
        public DbSet<Ai> ais { get; set; }
        public DbSet<RegisterServiceProvider> registerServiceProviders { get; set; }
        public DbSet<PregnancyDiagnosis> pregnancyDiagnoses { get; set; }
        public DbSet<Calving> calvings { get; set; }
        public DbSet<InstitutionRegForService> institutionRegForServices { get; set; }
        public DbSet<PregnancyTermination> pregnancyTerminations { get; set; }
        public DbSet<CalfReg> calfRegs { get; set; }
        public DbSet<SemenCollection> semenCollections { get; set; }
        public DbSet<SemenCollectionCenter> semenCollectionCenters { get; set; }
        public DbSet<AnimalSelection> animalSelections { get; set; }
        public DbSet<ResponsibleCollectorRegister> responsibleCollectorRegisters { get; set; }




    }
}
