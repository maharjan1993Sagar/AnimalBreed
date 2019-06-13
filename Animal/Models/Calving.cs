using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_calving")]
    public class Calving
    {
        public int id { get; set; }
        public string earTagNo { get; set; }
        public string serviceProviderId { get; set; }
        public DateTime calvingDate { get; set; }
        public string calvingType { get; set; }
        public string calvingCase { get; set; }

    }
}
