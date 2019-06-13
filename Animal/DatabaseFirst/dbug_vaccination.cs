namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbug_vaccination
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dbug_vaccination()
        {
            dbug_vaccinationAnimal = new HashSet<dbug_vaccinationAnimal>();
        }

        public int id { get; set; }

        public string vaccinName { get; set; }

        public int? vaccinTypeId { get; set; }

        public int? vaccinationSubTypeId { get; set; }

        public string vaccinForm { get; set; }

        public string manufacturedBy { get; set; }

        public int? vaccinationTypeid { get; set; }

        public virtual dbug_vaccinationSubType dbug_vaccinationSubType { get; set; }

        public virtual dbug_vaccinationType dbug_vaccinationType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbug_vaccinationAnimal> dbug_vaccinationAnimal { get; set; }
    }
}
