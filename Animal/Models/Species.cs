
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_Species")]
    public class Species
    {
        public int id { get; set; }
        public string speciesName { get; set; }
        public string  originFrom { get; set; }
        public string shortNotes { get; set; }

        public virtual ICollection<Breed> Breeds { get; set; }

        public virtual ICollection<AnimalRegistration> AnimalRegistrations { get; set; }

        public virtual ICollection<Species> Speciess { get; set; }
    }
}
