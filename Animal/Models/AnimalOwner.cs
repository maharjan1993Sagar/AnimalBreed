using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    public class AnimalOwner
    {
        public int AnimalId { get; set; }
        public AnimalRegistration AnimalRegistration { get; set; }
        public int OwnerId { get; set; }
        public OwnerKeeper Owner { get; set; }
    }
}
