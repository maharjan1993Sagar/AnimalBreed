using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_animal")]
    public class AnimalRegistration
    {
        public int id { get; set; }

        public string earTagNo { get; set; }

        public string weight { get; set; }

       

        public int? breedId { get; set; }

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

        public int? speciesId { get; set; }

        public int? keeperId { get; set; }

      
        public int? farmId { get; set; }

        public string gender { get; set; }

        public string declaredBy { get; set; }

        
        public DateTime declaredDate { get; set; }

        public virtual Breed Breed { get; set; }
      
        public virtual Species Species { get; set; }


        public virtual ICollection<GrowthMonitoring> GrowtthMonitorings { get; set; }

       
        public virtual ICollection<MilkRecord> MilkRecords { get; set; }


        public virtual ICollection<AnimalOwner> AnimalOwners { get; set; }

        public virtual ICollection<HealthCheckUp> HealthCheckUps { get; set; }

        public virtual ICollection<Diseases> Diseases { get; set; }
    }
}
