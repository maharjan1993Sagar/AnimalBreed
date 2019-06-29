using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_pregnancyBaseNutrition")]
    public class PregnancyBaseNutrition
    {
        public int id { get; set; }

        public int? speciesId { get; set; }

        public string breed { get; set; }

        public string weight { get; set; }

        public string PregrenencyType { get; set; }
   
        public string ageOfAnimal { get; set; }

        public string fatPercentage { get; set; }

        public string snf { get; set; }

        public string dm { get; set; }

        public string cp { get; set; }

        public string tdn { get; set; }

        public string ndf { get; set; }

        public string c { get; set; }

        public string p { get; set; }

        public virtual Species Species { get; set; }
        public string milkVolumn { get; set; }
    }
}
