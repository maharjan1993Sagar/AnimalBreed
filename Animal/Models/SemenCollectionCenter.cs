using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_semenCollectionCenter")]
    public class SemenCollectionCenter
    {
        public int id { get; set; }
        public string collectionCenterName { get; set; }
        public string registerNo { get; set; }
        public string address { get; set; }
        public string mun { get; set; }
        public string ward { get; set; }
        public string state { get; set; }
        public virtual SemenCollection SemenCollection { get; set; }
    }
}
