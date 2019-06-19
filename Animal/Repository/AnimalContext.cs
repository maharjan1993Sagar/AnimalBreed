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
        public DbSet<AnimalRegistration> animalRegistration { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Diseases> Diseases{ get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<FeedFooder> FeedFooder { get; set; }
        public DbSet<GrowthMonitoring> GrowthMonitorings { get; set; }
        public DbSet<HealthCheckUp> HealthCheckUps { get; set; }
        public DbSet<MIlkBaseNutrition> MilkBaseNutritions { get; set; }
        public DbSet<MilkRecord> MilkRecords { get; set; }
        public DbSet<OwnerKeeper> OwnerKeeper { get; set; }
        public DbSet<PregnancyBaseNutrition> PregnancyBaseNutritions { get; set; }
       
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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalOwner>()
                .HasKey(bc => new { bc.AnimalId, bc.OwnerId });
            modelBuilder.Entity<AnimalOwner>()
                .HasOne(bc => bc.Owner)
                .WithMany(b => b.AnimalOwners)
                .HasForeignKey(bc => bc.OwnerId);
            modelBuilder.Entity<AnimalOwner>()
                .HasOne(bc => bc.AnimalRegistration)
                .WithMany(c => c.AnimalOwners)
                .HasForeignKey(bc => bc.AnimalId);
        }



    }
}
