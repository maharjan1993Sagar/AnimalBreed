using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_diseases")]
    public class Diseases
    {
        public int id { get; set; }
        public string diseasesNameEng { get; set; }
        public string diseasesNameNep { get; set; }
        public string symptom { get; set; }
        public string shortNote { get; set; }

       
    }
}
