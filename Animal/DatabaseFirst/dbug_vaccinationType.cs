namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbug_vaccinationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dbug_vaccinationType()
        {
            dbug_vaccination = new HashSet<dbug_vaccination>();
            dbug_vaccinationSubType = new HashSet<dbug_vaccinationSubType>();
        }

        public int id { get; set; }

        public string vaccinationName { get; set; }

        public string shortNote { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbug_vaccination> dbug_vaccination { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbug_vaccinationSubType> dbug_vaccinationSubType { get; set; }
    }
}
