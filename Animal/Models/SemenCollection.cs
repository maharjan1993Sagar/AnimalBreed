using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_semenCollection")]
    public class SemenCollection
    {
        public int id { get; set; }
        public string collectionCenterId { get; set; }
        public string bullId { get; set; }
        public string batchNo { get; set; }
        public DateTime collectionDate { get; set; }
        public string shortNote { get; set; }
        public string responsibleCollectorId { get; set; }
        public ICollection <SemenCollectionCenter> SemenCollectionCenters { get; set; }
    }
}
