namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbug_farm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dbug_farm()
        {
            dbug_ownerKeeper = new HashSet<dbug_ownerKeeper>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbug_ownerKeeper> dbug_ownerKeeper { get; set; }
    }
}
