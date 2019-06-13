using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
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
    }
}
