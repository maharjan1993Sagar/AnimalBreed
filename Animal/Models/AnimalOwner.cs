using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_animalOwner")]
    public class AnimalOwner
    {
        public int AnimalId { get; set; }
        public AnimalRegistration AnimalRegistration { get; set; }
        public int OwnerId { get; set; }
        public OwnerKeeper Owner { get; set; }
    }
}
