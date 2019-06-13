namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbug_vaccinationAnimal
    {
        public int id { get; set; }

        public string earTagNo { get; set; }

        public int serviceProviderId { get; set; }

        public int vaccinId { get; set; }

        public int? vaccinationid { get; set; }

        public int diseasesId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime vaccinationDate { get; set; }

        public string dosage { get; set; }

        public string batchNo { get; set; }

        public string charge { get; set; }

        public string receiptNo { get; set; }

        public virtual dbug_diseases dbug_diseases { get; set; }

        public virtual dbug_vaccination dbug_vaccination { get; set; }
    }
}
