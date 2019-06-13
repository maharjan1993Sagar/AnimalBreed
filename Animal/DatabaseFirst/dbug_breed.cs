namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbug_breed
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dbug_breed()
        {
            dbug_animal = new HashSet<dbug_animal>();
        }

        public int id { get; set; }

        public string breedNameShort { get; set; }

        public string breedNamelong { get; set; }

        public string shortDetail { get; set; }

        public string originFrom { get; set; }

        public string registeredBy { get; set; }

        public string updatedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime registeredDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbug_animal> dbug_animal { get; set; }
    }
}
