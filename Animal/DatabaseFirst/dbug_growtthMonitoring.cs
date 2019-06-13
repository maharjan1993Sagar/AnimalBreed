namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbug_growtthMonitoring
    {
        public int id { get; set; }

        public string earTagNo { get; set; }

        public string length { get; set; }

        public string girth { get; set; }

        public string weight { get; set; }

        public string shortNote { get; set; }

        public string monitoredBy { get; set; }

        public int? animalRegistrationid { get; set; }

        public virtual dbug_animal dbug_animal { get; set; }
    }
}
