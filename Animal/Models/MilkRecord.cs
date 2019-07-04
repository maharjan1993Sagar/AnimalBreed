using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_milkRecord")]
    public class MilkRecord
    {
        public int id { get; set; }

        public string earTagNumber { get; set; }

        public string milkingStatus { get; set; }

        public string recordingPeriod { get; set; }
     
        public DateTime recordingDate { get; set; }

        public string milkVolume { get; set; }

        public string milkSampleBoxNo { get; set; }

        public int? labId { get; set; }

        public string testingCharge { get; set; }

        public string receiptNo { get; set; }

        public string genericProblem { get; set; }

        public string vacination { get; set; }

        public string shortNote { get; set; }

        public int? animalRegistrationid { get; set; }

        public virtual AnimalRegistration animalRegistration { get; set; }

        public string fatPercentage { get; set; }

        public string snf { get; set; }

        public virtual lab lab { get; set; }
    }
}
