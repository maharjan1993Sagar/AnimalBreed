using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_farm")]
    public class Farm
    {
        public int id { get; set; }

        public string orgtanizationName { get; set; }

        public string shortDetail { get; set; }

        public string dateOfRegistration { get; set; }

        public string regCertification { get; set; }

        public string mobile1 { get; set; }

        public string mobile { get; set; }

        public string email { get; set; }

        public string url { get; set; }

        public string address { get; set; }

        public string municipility { get; set; }

        public string ward { get; set; }

        public string longitude { get; set; }

        public string latitude { get; set; }

        public string farmType { get; set; }

        public string land { get; set; }

        public string area { get; set; }

      
        public virtual ICollection<OwnerKeeper> OwnerKeepers { get; set; }
    }
}
