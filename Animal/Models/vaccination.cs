using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_vaccination")]
    public class Vaccination
    {
        public int id { get; set; }
        public string vaccinName { get; set; }
        public int? vaccinTypeId { get; set; }
        public int? vaccinationSubTypeId { get; set; }
        public string vaccinForm { get; set; }
        public string  manufacturedBy { get; set; }

        public virtual VaccinationType vaccinationType { get; set; }
        public virtual VaccinationSubType vaccinationSubType { get; set; }

        public ICollection<VaccinationAnimal> vaccinationAnimals { get; set; }
    }
}
