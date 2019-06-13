using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Models
{
    [Table("dbug_vaccinationAnimal")]
    public class VaccinationAnimal
    {
        public int id { get; set; }
        public string earTagNo { get; set; }
      
      //  public int? vaccinTypeId { get; set; }
      //  public int? vaccinSubTypeId { get; set; }
        public int serviceProviderId { get; set; }
        public int  vaccinId { get; set; }
        public Vaccination vaccination { get; set; } 

        public int diseasesId { get; set; }
        public Diseases diseases { get; set; }

        public DateTime vaccinationDate { get; set; }
        public string dosage { get; set; }
        public string batchNo { get; set; }
        public string charge { get; set; }
        public string receiptNo { get; set; }




    }
}
