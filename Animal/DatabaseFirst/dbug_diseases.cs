namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbug_diseases
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dbug_diseases()
        {
            dbug_vaccinationAnimal = new HashSet<dbug_vaccinationAnimal>();
        }

        public int id { get; set; }

        public string diseasesNameEng { get; set; }

        public string diseasesNameNep { get; set; }

        public string symptom { get; set; }

        public string shortNote { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbug_vaccinationAnimal> dbug_vaccinationAnimal { get; set; }
    }
}
