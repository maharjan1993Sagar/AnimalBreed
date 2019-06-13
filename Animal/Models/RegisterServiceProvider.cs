using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_registerServiceProvider")]
    public class RegisterServiceProvider
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string address { get; set; }
        public string professionType { get; set; }
        public string mub  { get; set; }
        public string wardNo { get; set; }
        public string state { get; set; }
        public string provenDocument { get; set; }
        public string academicQualification { get; set; }
        public string certificate { get; set; }
        public string license { get; set; }
        public string  phone1 { get; set; }
        public string phone2 { get; set; }
        public string  email { get; set; }
        public string idCardNo { get; set; }
        public virtual Ai Ai { get; set; }
        public virtual PregnancyDiagnosis PregnencyDiagnosis { get; set; }
        public virtual  Calving Calving { get; set; }
        public virtual PregnancyTermination PregnencyTermination { get; set; }

    }
}
