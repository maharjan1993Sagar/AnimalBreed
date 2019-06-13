using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_animalSelection")]
    public class AnimalSelection
    {
        public int id { get; set; }
        public string animalId { get; set; }
        public string ownerId { get; set; }
        public string farmId { get; set; }
        public DateTime selectionDate { get; set; }
        public string shortNotes { get; set; }
    }
}
