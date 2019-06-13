using Animal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Repository
{
    public class VaccinationRepository:IVaccinationRepository
    {
        private AnimalContext _context;
        public VaccinationRepository(AnimalContext context)
        {
            _context = context;
        }
       
        private IRepository<Vaccination> _vaccination;
        private IRepository<VaccinationType> _vaccinationType;
        private IRepository<VaccinationSubType> _vaccinationSubType;
        private IRepository<VaccinationAnimal> _vaccinationAnimal;

        public IRepository<Vaccination> Vaccination
        {
            get
            {
                if (_vaccination == null)
                {
                    _vaccination = new Repository<Vaccination>(_context);
                }

                return _vaccination;
            }

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
