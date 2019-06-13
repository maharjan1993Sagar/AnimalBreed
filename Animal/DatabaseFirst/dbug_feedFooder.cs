namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dbug_FeedFooder
    {
        public int id { get; set; }

        public string fooderNameNep { get; set; }

        public string fooderNameEng { get; set; }

        public string address { get; set; }

        public string municipility { get; set; }

        public string district { get; set; }

        public string state { get; set; }

        public string shortNote { get; set; }

        public string cultivation { get; set; }

        public string seedingMethod { get; set; }

        public string seedHarvestingStorage { get; set; }

        public string grassProduct { get; set; }

        public string dm { get; set; }

        public string cp { get; set; }

        public string tdn { get; set; }

        public string ndf { get; set; }

        public string c { get; set; }

        public string p { get; set; }

        public string df { get; set; }

        public string adl { get; set; }

        public string tanni { get; set; }

        public string nitrateScore { get; set; }

        public string remarks { get; set; }

        public string price { get; set; }
    }
}
