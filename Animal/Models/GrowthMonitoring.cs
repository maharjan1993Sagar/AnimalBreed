using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_growthMonitoring")]
    public class GrowthMonitoring
    {

        public int id { get; set; }

        public string earTagNo { get; set; }

        public string length { get; set; }

        public string girth { get; set; }

        public string weight { get; set; }

        public string shortNote { get; set; }

        public string monitoredBy { get; set; }

        public int? animalRegistrationid { get; set; }

        public virtual AnimalRegistration aniamlRegistration { get; set; }
    }
}
