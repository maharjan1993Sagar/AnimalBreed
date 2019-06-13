using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_responsibleCollectorRegister")]
    public class ResponsibleCollectorRegister
    {
        public int id { get; set; }
        public string collectionCenterOrganizationId { get; set; }
        public string fullName { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string ward { get; set; }
        public string mun { get; set; }
        public string state { get; set; }
        public string academicQualification { get; set; }
        public string document { get; set; }
        public string licenseNo { get; set; }
        public string licenseImg { get; set; }
        public string citizenImg { get; set; }
        public virtual SemenCollection SemenCollection { get; set; }
    }
}
