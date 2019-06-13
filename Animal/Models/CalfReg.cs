using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_calfReg")]
    public class CalfReg
    {
        public int id { get; set; }
        public string earTag { get; set; }
        public string gender { get; set; }
        public string weight { get; set; }
        public string geneticDefect { get; set; }
        public string organizationalId { get; set; }
        public string ownerId { get; set; }
        public string keeperId { get; set; }
        public DateTime dob { get; set; }
        public string shortNotes { get; set; }
    }
}
