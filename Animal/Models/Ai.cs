using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_ai")]
    public class Ai
    {
        public int id { get; set; }
        public string earTagId { get; set; }
        public string semenBatchNo { get; set; }
        public string bullId { get; set; }
        public string semenDoseWasted { get; set; }
        public string inSemnatorId { get; set; }
        public string amounReceived { get; set; }
        public string recepitNo { get; set; }
        public string inSeminationPatch { get; set; }
        public DateTime previousInseminationDate { get; set; }
        public string locationNo { get; set; }

    }
}
