namespace WebApplication1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__EFMigrationsHistory> C__EFMigrationsHistory { get; set; }
        public virtual DbSet<dbug_animal> dbug_animal { get; set; }
        public virtual DbSet<dbug_breed> dbug_breed { get; set; }
        public virtual DbSet<dbug_diseases> dbug_diseases { get; set; }
        public virtual DbSet<dbug_farm> dbug_farm { get; set; }
        public virtual DbSet<dbug_feedFooder> dbug_feedFooder { get; set; }
        public virtual DbSet<dbug_growtthMonitoring> dbug_growtthMonitoring { get; set; }
        public virtual DbSet<dbug_milkBaseNutrition> dbug_milkBaseNutrition { get; set; }
        public virtual DbSet<dbug_milkRecord> dbug_milkRecord { get; set; }
        public virtual DbSet<dbug_ownerKeeper> dbug_ownerKeeper { get; set; }
        public virtual DbSet<dbug_pregnancyBaseNutrition> dbug_pregnancyBaseNutrition { get; set; }
        public virtual DbSet<dbug_vaccination> dbug_vaccination { get; set; }
        public virtual DbSet<dbug_vaccinationAnimal> dbug_vaccinationAnimal { get; set; }
        public virtual DbSet<dbug_vaccinationSubType> dbug_vaccinationSubType { get; set; }
        public virtual DbSet<dbug_vaccinationType> dbug_vaccinationType { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dbug_animal>()
                .HasMany(e => e.dbug_growtthMonitoring)
                .WithOptional(e => e.dbug_animal)
                .HasForeignKey(e => e.animalRegistrationid);

            modelBuilder.Entity<dbug_animal>()
                .HasMany(e => e.dbug_milkRecord)
                .WithOptional(e => e.dbug_animal)
                .HasForeignKey(e => e.animalRegistrationid);

            modelBuilder.Entity<dbug_animal>()
                .HasMany(e => e.dbug_ownerKeeper)
                .WithMany(e => e.dbug_animal)
                .Map(m => m.ToTable("AnimalOwner").MapLeftKey("animalId").MapRightKey("ownerId"));

            modelBuilder.Entity<dbug_breed>()
                .HasMany(e => e.dbug_animal)
                .WithRequired(e => e.dbug_breed)
                .HasForeignKey(e => e.breedId);

            modelBuilder.Entity<dbug_diseases>()
                .HasMany(e => e.dbug_vaccinationAnimal)
                .WithRequired(e => e.dbug_diseases)
                .HasForeignKey(e => e.diseasesId);

            modelBuilder.Entity<dbug_farm>()
                .HasMany(e => e.dbug_ownerKeeper)
                .WithOptional(e => e.dbug_farm)
                .HasForeignKey(e => e.farmid);

            modelBuilder.Entity<dbug_vaccination>()
                .HasMany(e => e.dbug_vaccinationAnimal)
                .WithOptional(e => e.dbug_vaccination)
                .HasForeignKey(e => e.vaccinationid);

            modelBuilder.Entity<dbug_vaccinationSubType>()
                .HasMany(e => e.dbug_vaccination)
                .WithOptional(e => e.dbug_vaccinationSubType)
                .HasForeignKey(e => e.vaccinationSubTypeId);

            modelBuilder.Entity<dbug_vaccinationType>()
                .HasMany(e => e.dbug_vaccination)
                .WithOptional(e => e.dbug_vaccinationType)
                .HasForeignKey(e => e.vaccinationTypeid);

            modelBuilder.Entity<dbug_vaccinationType>()
                .HasMany(e => e.dbug_vaccinationSubType)
                .WithOptional(e => e.dbug_vaccinationType)
                .HasForeignKey(e => e.VaccinationTypeid);
        }
    }
}
