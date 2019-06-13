namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbug_animal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dbug_animal()
        {
            dbug_growtthMonitoring = new HashSet<dbug_growtthMonitoring>();
            dbug_milkRecord = new HashSet<dbug_milkRecord>();
            dbug_ownerKeeper = new HashSet<dbug_ownerKeeper>();
        }




        public int id { get; set; }

        public string earTagNo { get; set; }

        public string weight { get; set; }

        public string species { get; set; }

        public int breedId { get; set; }

        public string age { get; set; }

        public string dob { get; set; }

        public int sireId { get; set; }

        public int damId { get; set; }

        public string noOfCalving { get; set; }

        public string lastCalvingDate { get; set; }

        public bool pregnencyStatus { get; set; }

        public string pregnencyDuration { get; set; }

        public bool milkingStatus { get; set; }

        public string createdAt { get; set; }

        public string updatedBy { get; set; }

        public int? ownerId { get; set; }

        public int? keeperId { get; set; }

        public int? farmId { get; set; }

        public string gender { get; set; }

        public string declaredBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime declaredDate { get; set; }

        public virtual dbug_breed dbug_breed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbug_growtthMonitoring> dbug_growtthMonitoring { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbug_milkRecord> dbug_milkRecord { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbug_ownerKeeper> dbug_ownerKeeper { get; set; }
    }
}
