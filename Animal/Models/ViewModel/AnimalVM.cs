using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models.ViewModel
{
    public class AnimalVM
    {
        public int id { get; set; }

        public string earTagNo { get; set; }

        public string weight { get; set; }

        public int? speciesId { get; set; }

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

        public int? keeperId { get; set; }

        public int? farmId { get; set; }

        public string gender { get; set; }

        public string declaredBy { get; set; }


        public DateTime declaredDate { get; set; }

        public SelectList breeds { get; set; }
        
        public SelectList farms { get; set; }

        public SelectList owners { get; set; }
        public SelectList dams { get; set; }
        public SelectList sires { get; set; }
        public SelectList speciess { get; set; }
        public SelectList keepers { get; set; }

      
    }
}
