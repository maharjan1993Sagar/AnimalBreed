using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_pregnancyTermination")]
    public class PregnancyTermination
    {
        public int id { get; set; }
        public string earTagNo { get; set; }
        public string serviceProvidedId { get; set; }
        public DateTime terminationDate { get; set; }
        public string terminationType { get; set; }
    }
}
