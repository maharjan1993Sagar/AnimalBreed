using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_pregnancyDiagnosis")]
    public class PregnancyDiagnosis
    {
        public int id { get; set; }
        public string earTagId { get; set; }
        public string serviceProviderId { get; set; }
        public string naturalService { get; set; }
        public string otherServices { get; set; }
        public string serviceName { get; set; }
        public DateTime diagnosisDate {get; set; }
        public string result { get; set; }
    }
}
