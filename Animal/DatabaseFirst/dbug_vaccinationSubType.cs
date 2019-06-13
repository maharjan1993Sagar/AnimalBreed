namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbug_vaccinationSubType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dbug_vaccinationSubType()
        {
            dbug_vaccination = new HashSet<dbug_vaccination>();
        }

        public int id { get; set; }

        public string SubTypeName { get; set; }

        public int? VaccinationTypeid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbug_vaccination> dbug_vaccination { get; set; }

        public virtual dbug_vaccinationType dbug_vaccinationType { get; set; }
    }
}
