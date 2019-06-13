namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbug_pregnancyBaseNutrition
    {
        public int id { get; set; }

        public string animalSpecies { get; set; }

        public string breed { get; set; }

        public string earlyPreg { get; set; }

        public string midPreg { get; set; }

        public string latePreg { get; set; }

        public string ageOfAnimal { get; set; }

        public string fatPercentage { get; set; }

        public string snf { get; set; }

        public string dp { get; set; }

        public string cp { get; set; }

        public string tdn { get; set; }

        public string ndf { get; set; }

        public string c { get; set; }

        public string p { get; set; }
    }
}
