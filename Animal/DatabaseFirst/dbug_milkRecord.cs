namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbug_milkRecord
    {
        public int id { get; set; }

        public string earTagNumber { get; set; }

        public bool milkingStatus { get; set; }

        public string recordingPeriod { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime recordingDate { get; set; }

        public string milkVolume { get; set; }

        public string milkSampleBoxNo { get; set; }

        public string labId { get; set; }

        public string testingCharge { get; set; }

        public string receiptNo { get; set; }

        public string genericProblem { get; set; }

        public string vacination { get; set; }

        public string shortNote { get; set; }

        public int? animalRegistrationid { get; set; }

        public virtual dbug_animal dbug_animal { get; set; }
    }
}
