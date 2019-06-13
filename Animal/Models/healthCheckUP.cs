using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_healthCheckUp")]
    public class HealthCheckUp
    {
        public int id { get; set; }
        public string earTagNo { get; set; }
        public int? diseasesId { get; set; }
        public int? serviceProviderId { get; set; }
        public DateTime sampleTakenDate { get; set; }
        public string sampleBoxNo { get; set; }
        public int? laboratoryId { get; set; }
        public string charge { get; set; }
        public string receiptNo { get; set; }
        public string anlyzeReport { get; set; }
        public DateTime reportExpDate { get; set; }
        public virtual AnimalRegistration animalRegistration { get; set; }
    }
}
