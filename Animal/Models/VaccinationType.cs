using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_vaccinationType")]
    public class VaccinationType
    {
        public int id { get; set; }
        public string vaccinationName { get; set; }
        public string shortNote { get; set; }

        public ICollection<VaccinationSubType> VaccinationSubTypes { get; set; }
    }
}
