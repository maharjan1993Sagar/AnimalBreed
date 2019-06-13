using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_vaccinationSubType")]
    public class VaccinationSubType
    {
        public int id { get; set; }
        public string  SubTypeName { get; set; }
        public int  VaccinationTypeId { get; set; }

        public virtual VaccinationType VaccinationType { get; set; }
    }
}
