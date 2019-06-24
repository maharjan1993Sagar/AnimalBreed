using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_GeneralNutration")]
    public class GeneralNutration
    {
        public int id { get; set; }

        public string animalSpecies { get; set; }

        public string weight { get; set; }

        public string snf { get; set; }

        public string dm { get; set; }





        public string dcp { get; set; }

        public string tdn { get; set; }

        public string ndf { get; set; }

        public string c { get; set; }

        public string p { get; set; }
    }
}
