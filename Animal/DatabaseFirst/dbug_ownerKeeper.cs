namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbug_ownerKeeper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dbug_ownerKeeper()
        {
            dbug_animal = new HashSet<dbug_animal>();
        }

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

        public virtual dbug_farm dbug_farm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbug_animal> dbug_animal { get; set; }
    }
}
