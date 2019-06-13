using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_ownerKeeper")]
    public class OwnerKeeper
    {
        public int id { get; set; }

        public string category { get; set; }

        public string fullName { get; set; }

        public string occupation { get; set; }

        public string address { get; set; }

        public string municipililty { get; set; }

        public string wardNo { get; set; }

        public string state { get; set; }

        public string latitude { get; set; }

        public string logitude { get; set; }

        public string dob { get; set; }

        public string academicQualification { get; set; }

        public string finantanceStatus { get; set; }

        public string mobileNumber { get; set; }

        public string otherNumber { get; set; }

        public string email { get; set; }

        public string url { get; set; }

        public int? farmid { get; set; }

        public virtual Farm farm { get; set; }

        
        public virtual ICollection<AnimalOwner> AnimalOwners { get; set; }
    }
}
