using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_breedAnimal")]
    public class Breed
    {
        public int id { get; set; }

        public string breedNameShort { get; set; }

        public string breedNamelong { get; set; }

        public string shortDetail { get; set; }

        public string originFrom { get; set; }

        public string registeredBy { get; set; }

        public string updatedBy { get; set; }

       
        public DateTime registeredDate { get; set; }

        public int? speciesId { get; set; }


        public virtual Species species { get; set; }

        public virtual ICollection<AnimalRegistration> AnimalRegistrations { get; set; }
    }
}
