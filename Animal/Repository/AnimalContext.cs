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

    }
}
